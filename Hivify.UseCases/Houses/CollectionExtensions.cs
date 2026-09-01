using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Houses.Commands.AddTenant;
using Hivify.UseCases.Houses.Commands.CreateHouse;
using Hivify.UseCases.Houses.Commands.DeleteTenant;
using Hivify.UseCases.Houses.Commands.UpdateHouse;
using Hivify.UseCases.Houses.DTOs;
using Hivify.UseCases.Houses.Queries.GetHouse;
using Hivify.UseCases.Houses.Queries.GetHouses;
using Hivify.UseCases.Houses.Queries.GetHouseTenants;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Houses;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddHouseServices()
        {

            services.AddScoped<ICommandHandler<AddHouseCommand, Guid>, AddHouseCommandHandler>();
            services.AddScoped<ICommandHandler<AddHouseTenantCommand, Guid>, AddHouseTenantCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateHouseCommand, bool>, UpdateHouseCommandHandler>();
            services.AddScoped<IQueryHandler<GetHousesQuery, IReadOnlyList<HouseListItemDto>>, GetHousesQueryHandler>();
            services.AddScoped<IQueryHandler<GetHouseQuery, HouseListItemDto>, GetHouseQueryHandler>();
            services.AddScoped<ICommandHandler<RemoveHouseTenantCommand, bool>, RemoveHouseTenantCommandHandler>();
            services.AddScoped<IQueryHandler<GetHouseTenantsQuery, IReadOnlyList<TenantListItemDto>>, GetHouseTenantsQueryHandler>();

            return services;
        }
    }
}