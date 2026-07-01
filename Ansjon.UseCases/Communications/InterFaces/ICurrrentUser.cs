namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface ICurrentUser
    {
        Task<Guid> GetUserIdAsync();


    }
}
