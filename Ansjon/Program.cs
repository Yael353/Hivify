using Ansjon.Components;
using Ansjon.Components.Account;
using Ansjon.Infrastructures.Data;
using Ansjon.Infrastructures.Identity;
using Ansjon.Infrastructures.Repositories.CommunicationRepos;
using Ansjon.Infrastructures.Repositories.ComplaintRepos;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Communications.ComplaintUseCases;
using Ansjon.UseCases.Communications.DTOs.ComplaintsDto;
using Ansjon.UseCases.Communications.FeedUseCases;
using Ansjon.UseCases.Communications.InterFaces;
using Ansjon.UseCases.Communications.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    }).AddIdentityCookies();


builder.Services.AddAuthorization();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// Yas-odi 
builder.Services.AddScoped<ICommunicationRepo, CommunicationRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<IValidator<CreateComplaintDto>, ComplaintDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateComplaintDto>, UpdateComplaintDtoValidator>();
builder.Services.AddFeedServices();
builder.Services.AddComplaintServices();
builder.Services.AddMudServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
.AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await IdentitySeeder.SeedAsync(services);

    var db = services.GetRequiredService<ApplicationDbContext>();

    await DatabaseSeeder.SeedAsync(db);
}


app.Run();
