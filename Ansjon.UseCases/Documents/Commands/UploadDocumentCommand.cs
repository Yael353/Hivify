using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Documents.Commands
{
    public sealed record UploadDocumentCommand(
        string FileName,
        string ContentType,
        Stream Content
    ) : ICommand<string>;
}
