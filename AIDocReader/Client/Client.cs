using Azure;
using Azure.AI.DocumentIntelligence;

namespace AIDocReader.Client
{
    public class Client : IClient 
    {

        private readonly DocumentIntelligenceClient _client;
        public async Task<DocumentIntelligenceClient> Client(IConfiguration configuration) 
        {
            // Fetch values from appsettings.json
            string? endpoint = configuration["AzureAI:Endpoint"];
            string? apiKey = configuration["AzureAI:ApiKey"];

            // Validate values
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("Azure AI endpoint or API key is missing in appsettings.json.");
            }

            // Initialize AzureKeyCredential and DocumentIntelligenceClient
            var credential = new AzureKeyCredential(apiKey);
            return new DocumentIntelligenceClient(new Uri(endpoint), credential);
        }

        public async Task<AnalyzeDocumentOperation> AnalyzeDocumentAsync(Stream documentStream)
        {
            return await _client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", documentStream);
        }
    }
}
