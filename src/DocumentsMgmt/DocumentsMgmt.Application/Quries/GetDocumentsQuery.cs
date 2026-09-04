using BuildingBlocks.ApplicationPorts.Messeging;
using BuildingBlocks.ApplicationPorts.Storage;

namespace DocumentsMgmt.Application.Quries
{
    public sealed record GetDocumentsQuery : IQuery<IReadOnlyList<FileDocumentResult>>;
}
