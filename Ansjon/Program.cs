using Ansjon.Components;
using Ansjon.Components.Account;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Infrastructures.ContextProviders;
using Ansjon.Infrastructures.Data;
using Ansjon.Infrastructures.Identity;
using Ansjon.Infrastructures.Repositories.AssociationRepo;
using Ansjon.Infrastructures.Repositories.ComplaintRepos;
using Ansjon.Infrastructures.Repositories.FeedRepo;
using Ansjon.Infrastructures.Repositories.HouseRepo;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Association.Commands;
using Ansjon.UseCases.Association.Handlers;
using Ansjon.UseCases.Common.Messaging;
using Ansjon.UseCases.Common.Validators;
using Ansjon.UseCases.Complaints.DTOs;
using Ansjon.UseCases.Feeds;
using Ansjon.UseCases.Houses.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<IUserManagementService, UserManagementService>();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>,
    IdentityNoOpEmailSender>();



#endregion

#region Infrastructure

builder.Services.AddScoped<IFeedRepo, FeedRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUserProvider>();
builder.Services.AddScoped<ICommandHandler<AddHouseCommand, HouseID>, AddHouseCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AddHouseTenantCommand, TenantID>, AddHouseTenantCommandHandler>();
builder.Services.AddScoped<IAssociationRepository, AssociationRepository>();
builder.Services.AddScoped<IHouseRepo, HouseRepo>();


#endregion

#region Application

builder.Services.AddFeedServices();
builder.Services.AddComplaintServices();

builder.Services.AddScoped<IValidator<CreateComplaintDto>,
    ComplaintDtoValidator>();

builder.Services.AddScoped<IValidator<UpdateComplaintDto>,
    UpdateComplaintDtoValidator>();

builder.Services.AddScoped<
    ICommandHandler<AddStaffMemberCommand, MemberID>,
    AddStaffMemberCommandHandler>();

builder.Services.AddScoped<ISender, Sender>();
builder.Services.AddScoped<IQuerySender, QuerySender>();
builder.Services.AddScoped<ICurrentAssociationProvider, CurrentAssociationProvider>();
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
