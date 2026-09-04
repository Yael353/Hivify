using BuildingBlocks.ApplicationPorts.Storage;
using SharedKernel.Messaging;

namespace DocumentsMgmt.Application
{
    public sealed record GetDocumentsQuery : IQuery<IReadOnlyList<FileDocumentResult>>;
}
