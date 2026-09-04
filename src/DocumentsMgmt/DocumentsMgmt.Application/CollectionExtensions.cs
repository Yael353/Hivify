using BuildingBlocks.ApplicationPorts.Storage;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Messaging;

namespace DocumentsMgmt.Application;

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