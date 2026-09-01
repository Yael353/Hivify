using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Common.Validators;
using Hivify.UseCases.Complaints.Commands.CreateComplaint;
using Hivify.UseCases.Complaints.Commands.UpdateComplaintStatus;
using Hivify.UseCases.Complaints.DTOs;
using Hivify.UseCases.Complaints.Queries.GetComplaint;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Complaints;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddComplaintServices(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<ICommandHandler<CreateComplaintCommand, Guid>, CreateComplaintCommandHandler>();
        services.AddScoped<IQueryHandler<GetComplaintByIdQuery, ComplaintListItemDto?>, GetComplaintByIdQueryHandler>();
        services.AddScoped<ICommandHandler<UpdateComplaintStatusCommand, bool>, UpdateComplaintStatusCommandHandler>();

        // Queries
        services.AddScoped<IQueryHandler<GetUserComplaintsQuery, IReadOnlyList<ComplaintListItemDto>>, GetUserComplaintsQueryHandler>();
        services.AddScoped<IQueryHandler<GetAllComplaintsQuery, IReadOnlyList<ComplaintListItemDto>>, GetAllComplaintsQueryHandler>();

        // Validators
        services.AddScoped<IValidator<CreateComplaintDto>, ComplaintDtoValidator>();
        services.AddScoped<IValidator<UpdateComplaintDto>, UpdateComplaintDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateComplaintCommandValidator>();

        return services;
    }
}