using BuildingBlocks.ApplicationPorts.Messeging;
using Complaints.Application.Commands.CreateComplaint;
using Complaints.Application.Commands.UpdateComplaintStatus;
using Complaints.Application.Contracts;
using Complaints.Application.Queries.GetComplaint;
using Complaints.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Complaints.Application;

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
        services.AddScoped<IValidator<CreateComplaint>, CreateComplaintDtoValidator>();
        services.AddScoped<IValidator<UpdateComplaint>, UpdateComplaintDtoValidator>();

        return services;
    }
}