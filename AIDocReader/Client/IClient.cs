using Azure.AI.DocumentIntelligence;

namespace AIDocReader.Client
{
    public interface IClient
    {
        Task<AnalyzeResult> AnalyzeDocumentAsync(CancellationToken token);
    }
}
