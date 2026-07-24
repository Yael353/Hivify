using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Ansjon.AI.Agents
{
    public class AnsjonAgent : IAnsjonAgent
    {
        private readonly AIAgent _agent;

        public AnsjonAgent(IChatClient chatClient)
        {
            _agent = chatClient.AsAIAgent(
                name: "Ansjon",
                instructions: "You are a helpful landlord assistant.");
        }

        public async Task<string> AskAsync(string message)
        {
            var response = await _agent.RunAsync(message);
            return response.Text;
        }
    }
}
