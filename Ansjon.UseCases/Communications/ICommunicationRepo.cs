using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications
{
    public interface ICommunicationRepo
    {
        Task<Feed> CreateFeedAsync();
        Task<IEnumerable<Feed>> GetAllFeedsAsync();

    }
}
