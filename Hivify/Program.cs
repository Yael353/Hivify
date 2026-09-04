using Hivify.Components;
using Hivify.Components.Account;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using ServiceDefaults;


var builder = WebApplication.CreateBuilder(args);

#region Presentation

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

#endregion

#region Authentication & Authorization

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services.AddAuthorization();

#endregion

#region Database

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Scoped context for Identity and other code that explicitly
// requires ApplicationDbContext.
builder.Services.AddScoped<ApplicationDbContext>(sp =>
{
    var factory =
        sp.GetRequiredService<
            IDbContextFactory<ApplicationDbContext>>();

    return factory.CreateDbContext();
});

#endregion

#region Storage
builder.Services.Configure<CloudinaryOptions>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.AddStorageServices();
#endregion

#region Identity

builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.SchemaVersion =
            IdentitySchemaVersions.Version3;
    })
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<
    IUserRepo,
    UsersRepo>();

builder.Services.AddSingleton<
    IEmailSender<ApplicationUser>,
    IdentityNoOpEmailSender>();

#endregion

#region Infrastructure
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUserProvider>();
builder.Services.AddScoped<IFeedRepo, FeedRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddScoped<IAssociationRepo, AssociationRepo>();
builder.Services.AddScoped<IHouseRepo, HouseRepo>();
builder.Services.AddScoped<IUserRepo, UsersRepo>();


#endregion

#region Application
builder.Services.AddScoped<ISender, Sender>();
builder.Services.AddScoped<IQuerySender, QuerySender>();
builder.Services.AddFeedServices();
builder.Services.AddHouseServices();
builder.Services.AddAdminServices();
builder.Services.AddAssociationServices();
builder.Services.AddComplaintServices();
builder.Services.AddRazorComponents();
builder.Services.AddComplaintServices();
builder.Services.AddDocumentServices();


#endregion

#region AI Integration
builder.Services.AddHivifyAIServices();
#endregion


builder.AddServiceDefaults();

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseAntiforgery();

#endregion

#region Endpoints
app.MapDefaultEndpoints();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

#endregion

#region Database Seeding

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await IdentitySeeder.SeedAsync(services);

    var db = services.GetRequiredService<ApplicationDbContext>();

    await DatabaseSeeder.SeedAsync(db);
}

#endregion

app.Run();
