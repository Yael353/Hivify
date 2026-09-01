using Association.Application.Commands.AddAssociation;
using Association.Application.Commands.AddStaffMember;
using Association.Application.Commands.RemoveStaffMember;
using Association.Application.Commands.UpdateStaffMemberRole;
using Association.Application.DTOs;
using Association.Application.Queries.GetAssociation;
using Association.Application.Queries.GetAssociations;
using Association.Domain;
using Association.Domain.Members;
using Hivify.UseCases.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Association.Application;

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