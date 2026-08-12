using Ansjon.UseCases.Feeds.DTOs;

namespace Ansjon.UseCases.Abstractions.Services
{
    public interface IFeedGenerator
    {
        Task<GeneratedFeedDto> GenerateAsync(string instruction);
    }
}
