using Ansjon.UseCases.Communications.InterFaces;
using Microsoft.Extensions.AI;

namespace Ansjon.AI.Services
{
    public class FeedGenerator : IFeedGenerator
    {
        private readonly IChatClient _client;


        public FeedGenerator(IChatClient client)
        {
            _client = client;
        }


        public async Task<CreateFeedDto> GenerateAsync(string instruction)
        {

            var prompt = $$"""
            You are a municipality communication assistant.

            Your task is to create a public announcement feed for citizens.

            Requirements:
            - Create a clear and informative title.
            - Write professional and easy-to-understand content.
            - The announcement must be suitable for citizens.
            - Do not invent facts or add information that is not provided.
            - If information is missing, keep the wording general.

            User request:
            {{instruction}}

            Return only valid JSON in this format:

            {
                "title": "",
                "content": ""
            }
            """;


            var response = await _client.GetResponseAsync(prompt);
            Console.WriteLine(response);


            // later we deserialize JSON here

            return new CreateFeedDto
            {
                Title = response.Text
            };
        }
    }
}
