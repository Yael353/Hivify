using Hivify.Core.Aggregates.Associations;
using Hivify.Core.Aggregates.Associations.Members;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Association.Commands.AddAssociation;
using Hivify.UseCases.Association.Commands.AddStaffMember;
using Hivify.UseCases.Association.Commands.RemoveStaffMember;
using Hivify.UseCases.Association.Commands.UpdateStaffMemberRole;
using Hivify.UseCases.Association.DTOs;
using Hivify.UseCases.Association.Queries.GetAssociation;
using Hivify.UseCases.Association.Queries.GetAssociations;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Association;

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
            services.AddScoped<ICommandHandler<RemoveStaffMemberCommand, bool>, RemoveStaffMemberCommandHandler>();
            services.AddScoped<
    ICommandHandler<UpdateStaffMemberRoleCommand, bool>,
    UpdateStaffMemberRoleCommandHandler>();

            return services;
        }
    }
}