using BuildingBlocks.ApplicationPorts.Storage;
using SharedKernel.Messaging;

namespace DocumentsMgmt.Application
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
