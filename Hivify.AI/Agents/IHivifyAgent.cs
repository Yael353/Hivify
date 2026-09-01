namespace Hivify.AI.Agents
{
    internal interface IHivifyAgent
    {
        Task<string> AskAsync(string message);

    }
}
