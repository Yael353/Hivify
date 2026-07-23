
using Ansjon.UseCases.Communications.ComplaintUseCases;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddComplaintServices()
        {
            services.AddScoped<CreateComplaint>();
            services.AddScoped<ViewComplaints>();
            services.AddScoped<UpdateComplaint>();
            services.AddScoped<DeleteComplaint>();

            return services;
        }
    }
}
