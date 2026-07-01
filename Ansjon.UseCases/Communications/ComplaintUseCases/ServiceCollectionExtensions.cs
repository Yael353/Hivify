
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddComplaintServices(this IServiceCollection services)
        {

            services.AddScoped<CreateComplaint>();
            services.AddScoped<ViewComplaints>();
            services.AddScoped<UpdateComplaint>();
            services.AddScoped<DeleteComplaint>();

            return services;
        }
    }

}
