namespace AIDocReader.Service
{
    public interface IService
    {
        Task<bool> CheckIfWordInDocument(string word);

        Task<string> ExtractDocumentWords(CancellationToken token);


    }
}
