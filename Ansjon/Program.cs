using Ansjon.Components;
using Ansjon.Components.Account;
using Ansjon.Infrastructures.Data;
using Ansjon.Infrastructures.Identity;
using Ansjon.Infrastructures.Repositories.ComplaintRepos;
using Ansjon.Infrastructures.Repositories.FeedRepo;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Abstractions.Services;
using Ansjon.UseCases.Communications.DTOs.ComplaintsDto;
using Ansjon.UseCases.Communications.FeedUseCases;
using Ansjon.UseCases.Communications.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ServiceDefaults;


var builder = WebApplication.CreateBuilder(args);

#region Presentation

builder.Services.AddRazorComponents()
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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Identity

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>,
    IdentityNoOpEmailSender>();

#endregion

#region Infrastructure

builder.Services.AddScoped<IFeedRepo, FeedRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

#endregion

#region Application

builder.Services.AddFeedServices();
builder.Services.AddComplaintServices();

builder.Services.AddScoped<IValidator<CreateComplaintDto>,
    ComplaintDtoValidator>();

builder.Services.AddScoped<IValidator<UpdateComplaintDto>,
    UpdateComplaintDtoValidator>();

#endregion

#region AI Integration
builder.Services.AddAnsjonAIServices();
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
