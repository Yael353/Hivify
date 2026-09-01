using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Documents.Commands;
using Hivify.UseCases.Documents.Quries;
using Hivify.UseCases.Documents.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Documents;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDocumentServices()
        {
            services.AddScoped<ICommandHandler<UploadDocumentCommand, string>, UploadDocumentCommandHandler>();
            services.AddScoped<IQueryHandler<GetDocumentsQuery, IReadOnlyList<FileDocumentResult>>, GetDocumentsQueryHandler>();

            return services;
        }
    }
}