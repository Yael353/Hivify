namespace Ansjon.UseCases.Documents.Results
{
    public sealed record FileUploadResult(
      string PublicId,
      string Url,
      string SecureUrl);
}
