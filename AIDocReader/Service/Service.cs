using Azure.AI.DocumentIntelligence;
using Azure;
using AIDocReader.Client;
using static System.Net.Mime.MediaTypeNames;

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
            if (string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(word), "Word to search cannot be null or empty.");

            // Open the file
            var file = _documentClient.AnalyzeDocumentAsync();
            var result = file.Result;
            var text = string.Empty;

            try
            {
                foreach (var page in result.Pages)
                {

                    Console.WriteLine($"Page {page.PageNumber}:");

                    foreach (var line in page.Lines)
                    {
                        foreach (var letter in line.Content)
                        {

                            Console.Write(letter);
                            text += letter;
                        }
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                // Log the error or rethrow it based on your use case
                throw new Exception("Failed to analyze the document.", ex);
            }

            return "ok";
        }

        
    }
}
