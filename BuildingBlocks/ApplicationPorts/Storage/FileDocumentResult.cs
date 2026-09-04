namespace BuildingBlocks.ApplicationPorts.Storage
{
    public sealed record FileDocumentResult(
      string PublicId,
      string FileName,
      string Url,
      string SecureUrl);
}
