using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Documents.Results;

namespace Ansjon.UseCases.Documents.Quries
{
    public sealed record GetDocumentsQuery : IQuery<IReadOnlyList<FileDocumentResult>>;
}
