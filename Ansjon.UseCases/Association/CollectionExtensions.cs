using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Association.Commands.AddAssociation;
using Ansjon.UseCases.Association.Commands.AddStaffMember;
using Ansjon.UseCases.Association.DTOs;
using Ansjon.UseCases.Association.Queries.GetAssociation;
using Ansjon.UseCases.Association.Queries.GetAssociations;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Association;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAssociationServices()
        {
            services.AddScoped<ICommandHandler<AddStaffMemberCommand, MemberID>, AddStaffMemberCommandHandler>();
            services.AddScoped<ICommandHandler<AddAssociationCommand, AssociationID>, CreateAssociationCommandHandler>();
            services.AddScoped<IQueryHandler<GetAssociationsQuery, IReadOnlyList<AssociationListDto>>, GetAssociationsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAssociationQuery, AssociationListDto>, GetAssociationQueryHandler>();

            return services;
        }
    }
}