using Azure.AI.DocumentIntelligence;

namespace AIDocReader.Client
{
    public interface IClient
    {
        DocumentIntelligenceClient GetClient();
    }
}
