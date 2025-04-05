using Azure;
using Azure.AI.DocumentIntelligence;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Azure;

namespace AIDocReader.Client
{
    public class Client : IClient 
    {

        private readonly DocumentIntelligenceClient _client;
        private readonly Uri _documentURI;

        public Client(IConfiguration configuration) 
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
            _client = new DocumentIntelligenceClient(new Uri(endpoint), credential);
            _documentURI = configuration["AzureAI:documentURI"];
        }

        public async Task<AnalyzeResult> AnalyzeDocumentAsync()
        {
            var operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", _documentURI);

            return operation.Value.ToObjectFromJson<AnalyzeResult>();
        }

        public async Task<AnalyzeResult> AnalyzeDocumentAsyncStream()
        {
            using var stream = await DownloadDocumentAsync(_documentURI);

            var operation = await _client.AnalyzeDocumentAsync(
                WaitUntil.Completed,
                "prebuilt-layout",
                stream);

            return operation.Value;
        }

        private async Task<Stream> DownloadDocumentAsync(Uri documentUri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(documentUri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }


    }
}
