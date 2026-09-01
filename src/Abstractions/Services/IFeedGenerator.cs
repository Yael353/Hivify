using Hivify.UseCases.Feeds.DTOs;

namespace Hivify.UseCases.Abstractions.Services
{
    public interface IFeedGenerator
    {
        Task<GeneratedFeedDto> GenerateAsync(string instruction);
    }
}
