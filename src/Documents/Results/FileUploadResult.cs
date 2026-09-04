namespace BuildingBlocks.ApplicationPorts.Storage
{
    public sealed record FileUploadResult(
      string PublicId,
      string Url,
      string SecureUrl);
}
