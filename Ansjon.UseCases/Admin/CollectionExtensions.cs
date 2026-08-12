using Ansjon.UseCases.Admin.Commands;
using Ansjon.UseCases.Admin.Queries;
using Ansjon.UseCases.Communications.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Admin;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFeedServices()
        {
            services.AddScoped<CreateFeed>();
            services.AddScoped<UpdateFeed>();
            services.AddScoped<DeleteFeed>();
            services.AddScoped<ViewFeeds>();

            services.AddValidatorsFromAssemblyContaining<CreateFeedDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateFeedDtoValidator>();

            return services;
        }
    }
}