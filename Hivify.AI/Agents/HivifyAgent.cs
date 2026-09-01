using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Hivify.AI.Agents
{
    public class HivifyAgent : IHivifyAgent
    {
        private readonly AIAgent _agent;

        public HivifyAgent(IChatClient chatClient)
        {
            _agent = chatClient.AsAIAgent(
                name: "Hivify",
                instructions: "You are a helpful landlord assistant.");
        }

        public async Task<string> AskAsync(string message)
        {
            var response = await _agent.RunAsync(message);
            return response.Text;
        }
    }
}
