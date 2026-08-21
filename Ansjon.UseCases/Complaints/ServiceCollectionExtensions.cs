using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Common.Validators;
using Ansjon.UseCases.Complaints.Commands.CreateComplaint;
using Ansjon.UseCases.Complaints.Commands.UpdateComplaintStatus;
using Ansjon.UseCases.Complaints.DTOs;
using Ansjon.UseCases.Complaints.Queries.GetComplaint;
using Ansjon.UseCases.Complaints.Queries.GetComplaintById;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Complaints;

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