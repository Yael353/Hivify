using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.AdminUserMgmt.DTOs;
using Hivify.UseCases.AdminUserMgmt.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.AdminUserMgmt;


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