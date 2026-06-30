namespace Ansjon.UseCases.Communications.interfaes
{
    internal interface ICurrentUser
    {
        string Id { get; }
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        string Email { get; }
    }
}
