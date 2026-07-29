namespace Ansjon.UseCases.Abstractions.Services
{
    public interface IFeedGenerator
    {
        Task<CreateFeedDto> GenerateAsync(string instruction);
    }
}
