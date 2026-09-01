using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Documents.Commands
{
    public sealed record UploadDocumentCommand(
        string FileName,
        string ContentType,
        Stream Content
    ) : ICommand<string>;
}
