using Complaints.Application.Contracts;
using FluentValidation;
using Hivify.UseCases.Complaints.Commands.CreateComplaint;
using Hivify.UseCases.Complaints.Commands.UpdateComplaintStatus;
using Hivify.UseCases.Complaints.Queries.GetComplaint;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddComplaintServices(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<ICommandHandler<CreateComplaintCommand, Guid>, CreateComplaintCommandHandler>();
        services.AddScoped<IQueryHandler<GetComplaintByIdQuery, ComplaintListItem?>, GetComplaintByIdQueryHandler>();
        services.AddScoped<ICommandHandler<UpdateComplaintStatusCommand, bool>, UpdateComplaintStatusCommandHandler>();

        // Queries
        services.AddScoped<IQueryHandler<GetUserComplaintsQuery, IReadOnlyList<ComplaintListItem>>, GetUserComplaintsQueryHandler>();
        services.AddScoped<IQueryHandler<GetAllComplaintsQuery, IReadOnlyList<ComplaintListItem>>, GetAllComplaintsQueryHandler>();

        // Validators
        services.AddScoped<IValidator<CreateComplaint>, ComplaintDtoValidator>();
        services.AddScoped<IValidator<UpdateComplaint>, UpdateComplaintDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateComplaintCommandValidator>();

        return services;
    }
}