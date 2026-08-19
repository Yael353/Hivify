using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Association.Commands.AddStaffMember;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Association;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAssociationServices()
        {


            services.AddScoped<ICommandHandler<AddStaffMemberCommand, MemberID>, AddStaffMemberCommandHandler>();

            return services;
        }
    }
}