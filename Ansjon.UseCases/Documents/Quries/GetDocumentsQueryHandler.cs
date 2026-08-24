using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Storage;
using Ansjon.UseCases.Documents.Results;

namespace Ansjon.UseCases.Documents.Quries
{
    public sealed class GetDocumentsQueryHandler
    : IQueryHandler<
        GetDocumentsQuery,
        IReadOnlyList<FileDocumentResult>>
    {
        private readonly IFileStorage _fileStorage;

        public GetDocumentsQueryHandler(
            IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        public async Task<IReadOnlyList<FileDocumentResult>> Handle(
            GetDocumentsQuery query,
            CancellationToken cancellationToken)
        {
            return await _fileStorage.GetAllAsync(
                cancellationToken);
        }
    }
}
