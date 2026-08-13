using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Houses.Commands.AddTenant;
using Ansjon.UseCases.Houses.Commands.CreateHouse;
using Ansjon.UseCases.Houses.Commands.UpdateHouse;
using Ansjon.UseCases.Houses.DTOs;
using Ansjon.UseCases.Houses.Queries.GetHouse;
using Ansjon.UseCases.Houses.Queries.GetHouses;
using Ansjon.UseCases.Houses.Queries.GetHouseTenants;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Houses;


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
            services.AddScoped<IQueryHandler<GetHouseTenantsQuery, IReadOnlyList<TenantListItemDto>>, GetHouseTenantsQueryHandler>();

            return services;
        }
    }
}