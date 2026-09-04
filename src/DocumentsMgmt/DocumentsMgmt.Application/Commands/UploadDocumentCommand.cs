using BuildingBlocks.ApplicationPorts.Messeging;

namespace DocumentsMgmt.Application.Commands
{
    public sealed record UploadDocumentCommand(
        string FileName,
        string ContentType,
        Stream Content
    ) : ICommand<string>;
}
