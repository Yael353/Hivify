namespace Ansjon.AI.Agents
{
    internal interface IAnsjonAgent
    {
        Task<string> AskAsync(string message);

    }
}
