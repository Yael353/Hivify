using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.AdminUserMgmt.DTOs;
using Ansjon.UseCases.AdminUserMgmt.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.AdminUserMgmt;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAdminServices()
        {


            services.AddScoped<IQueryHandler<GetUsersQuery, IReadOnlyList<UserListItem>>, GetUsersQueryHandler>();

            return services;
        }
    }
}