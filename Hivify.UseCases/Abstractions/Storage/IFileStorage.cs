using Hivify.UseCases.Documents.Results;

namespace Hivify.UseCases.Abstractions.Storage
{
    public interface IFileStorage
    {
        Task<FileUploadResult> UploadAsync(
            Stream stream,
            string fileName,
            string contentType,
            CancellationToken cancellationToken = default);
        Task<IReadOnlyList<FileDocumentResult>> GetAllAsync(CancellationToken cancellationToken = default);
    }


}
