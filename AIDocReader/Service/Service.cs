using Azure;
using AIDocReader.Client;
using System.Text;
using System.Text.RegularExpressions;
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


        public async Task<bool> CheckIfWordInDocument(string word, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException(nameof(word), "Word to search cannot be null or empty.");

            var text = await ExtractDocumentWords(token);

            

            // Use regex to match the word exactly, case-insensitive and with word boundaries
            var pattern = $@"\b{Regex.Escape(word)}\b";
            var match = Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);

            return match;
        }

        public async Task<string> ExtractDocumentWords(CancellationToken token)
        {

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

                // Normalise the text: trim and collapse multiple whitespaces
                return Regex.Replace(fullTextBuilder.ToString().Trim(), @"\s+", " ");
            }
            catch (RequestFailedException ex)
            {
                // Log the error or rethrow it based on your use case
                throw new Exception("Failed to analyze the document.", ex);
            }
        }

        
    }
}
