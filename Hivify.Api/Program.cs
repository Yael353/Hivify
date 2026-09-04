using Association.Application.Contracts;
using Houses.Infrastructure.Presistence;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();




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
builder.Services.AddScoped<IHouseRepository, HouseRepo>();
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
