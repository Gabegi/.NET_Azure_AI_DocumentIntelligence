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

        public async Task<string> CheckWordInDocument(string word)
        {
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

        public async Task<bool> InputCheck(string filePath, string wordToSearch)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(wordToSearch))
            {
                throw new ArgumentNullException(nameof(wordToSearch), "Word to search cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }
            return true;
        }
    }
}
