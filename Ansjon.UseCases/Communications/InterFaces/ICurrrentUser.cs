using Ansjon.Core.Aggregates.Feeds;

namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface ICurrentUser
    {
        Task<AuthorID> GetUserIdAsync();


    }
}
