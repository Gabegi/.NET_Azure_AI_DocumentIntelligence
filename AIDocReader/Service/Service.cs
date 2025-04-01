using Azure.AI.DocumentIntelligence;
using Azure;
using AIDocReader.Client;

namespace AIDocReader.Service
{
    public class Service : IService
    {
        private readonly IClient _documentClient;

        public Service(IClient documentClient)
        {
            _documentClient = documentClient;
        }

        // TO DO
        public async Task<string> CheckWordInDocument(string word)
        {
            if (string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(word), "Word to search cannot be null or empty.");

            // Open the file
            var file = _documentClient.AnalyzeDocumentAsync();

            try
            {
                
            }
            catch (RequestFailedException ex)
            {
                // Log the error or rethrow it based on your use case
                throw new Exception("Failed to analyze the document.", ex);
            }
        }

        
    }
}
