using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications
{
    public interface ICommunicationRepo
    {
        Task<IEnumerable<Feed>> GetAllFeedsAsync();
    }
}
