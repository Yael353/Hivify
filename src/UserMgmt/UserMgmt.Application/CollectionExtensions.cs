using Microsoft.Extensions.DependencyInjection;
using UserMgmt.Application.Contracts;
using UserMgmt.Application.Quries;

namespace UserMgmt.Application;


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