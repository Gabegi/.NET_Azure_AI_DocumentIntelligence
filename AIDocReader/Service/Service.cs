using Azure.AI.DocumentIntelligence;
using Azure;
using AIDocReader.Client;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace AIDocReader.Service
{
    public class Service : IService
    {
        private readonly IClient _documentClient;

        public Service(IClient documentClient)
        {
            _documentClient = documentClient;
        }



        public async Task<string> CheckWordInDocument(string word, CancellationToken token)
        {
            if (string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(word), "Word to search cannot be null or empty.");

            // Open the file
            var result = await _documentClient.AnalyzeDocumentAsync(token);

            try
            {
                var fullTextBuilder = new StringBuilder();

                foreach (var page in result.Pages)
                {
                    foreach (var line in page.Lines)
                    {
                        fullTextBuilder.AppendLine(line.Content); // Add full line text
                    }
                }

                return fullTextBuilder.ToString();

            }
            catch (RequestFailedException ex)
            {
                // Log the error or rethrow it based on your use case
                throw new Exception("Failed to analyze the document.", ex);
            }
        }

        
    }
}
