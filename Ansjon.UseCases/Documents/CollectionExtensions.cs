using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Documents.Commands;
using Ansjon.UseCases.Documents.Quries;
using Ansjon.UseCases.Documents.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Documents;


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