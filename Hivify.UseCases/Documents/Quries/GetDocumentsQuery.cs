using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Documents.Results;

namespace Hivify.UseCases.Documents.Quries
{
    public sealed record GetDocumentsQuery : IQuery<IReadOnlyList<FileDocumentResult>>;
}
