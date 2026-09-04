using SharedKernel.Messaging;

namespace DocumentsMgmt.Application
{
    public sealed record UploadDocumentCommand(
        string FileName,
        string ContentType,
        Stream Content
    ) : ICommand<string>;
}
