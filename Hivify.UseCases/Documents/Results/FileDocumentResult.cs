namespace Hivify.UseCases.Documents.Results
{
    public sealed record FileDocumentResult(
      string PublicId,
      string FileName,
      string Url,
      string SecureUrl);
}
