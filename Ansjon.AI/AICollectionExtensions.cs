

using Ansjon.AI.Agents;
using Ansjon.AI.Services;
using Ansjon.UseCases.Communications.InterFaces;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using OllamaSharp;





public static class AICollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAnsjonAIServices()
        {
            services.AddSingleton<IChatClient>(sp =>
            {
                return new OllamaApiClient(
                    new Uri("http://localhost:11434"),
                    "phi4-mini");
            });
            services.AddScoped<IAnsjonAgent, AnsjonAgent>();

            services.AddScoped<IFeedGenerator, FeedGenerator>();


            return services;
        }
    }
}


