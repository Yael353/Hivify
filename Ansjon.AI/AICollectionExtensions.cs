

using Ansjon.AI.Agents;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using OllamaSharp;

public static class AICollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAIServices()
        {
            services.AddSingleton<IChatClient>(sp =>
            {
                return new OllamaApiClient(
                    new Uri("http://localhost:11434"),
                    "phi4-mini");
            });
            services.AddScoped<IAnsjonAgent, AnsjonAgent>();


            return services;
        }
    }
}
