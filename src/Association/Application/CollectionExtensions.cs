using Association.Application.Commands.AddAssociation;
using Association.Application.DTOs;
using Association.Application.Queries.GetAssociation;
using Hivify.Association.Application.Commands.AddAssociation;
using Hivify.Association.Application.Commands.AddStaffMember;
using Hivify.Association.Application.Commands.RemoveStaffMember;
using Hivify.Association.Application.Commands.UpdateStaffMemberRole;
using Hivify.Association.Application.Queries.GetAssociations;
using Hivify.Association.Domain.Associations;
using Hivify.Association.Domain.Members;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Messaging;

namespace Hivify.Association.Application;

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
    ICommandHandler<UpdateStaffMemberRoleCommand, bool>, UpdateStaffMemberRoleCommandHandler>();

            return services;
        }
    }
}





