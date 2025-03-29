using Azure;
using Azure.AI.DocumentIntelligence;

namespace AIDocReader
{
    public class Client
    {

        private readonly DocumentIntelligenceClient _client;
        public Client(IConfiguration configuration)
        {
            // Fetch values from appsettings.json
            string endpoint = configuration?["AzureAI:Endpoint"];
            string apiKey = configuration?["AzureAI:ApiKey"];

            // Validate values
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("Azure AI endpoint or API key is missing in appsettings.json.");
            }

            // Initialize AzureKeyCredential and DocumentIntelligenceClient
            var credential = new AzureKeyCredential(apiKey);
            _client = new DocumentIntelligenceClient(new Uri(endpoint), credential);
        }

        public DocumentIntelligenceClient GetClient()
        {
            return _client;
        }
    }
}
