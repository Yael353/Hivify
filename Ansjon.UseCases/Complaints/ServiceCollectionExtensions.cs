using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Complaints.Commands.CreateComplaint;
using Ansjon.UseCases.Complaints.DTOs;
using Ansjon.UseCases.Complaints.Queries.GetComplaint;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Complaints;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddComplaintServices(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<ICommandHandler<CreateComplaintCommand, Guid>, CreateComplaintCommandHandler>();

        // Queries
        services.AddScoped<IQueryHandler<GetUserComplaintsQuery, IReadOnlyList<ComplaintListItemDto>>, GetUserComplaintsQueryHandler>();

        // Validators
        services.AddValidatorsFromAssemblyContaining<CreateComplaintCommandValidator>();

        return services;
    }
}