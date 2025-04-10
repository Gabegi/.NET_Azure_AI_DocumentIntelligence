namespace AIDocReader.Service
{
    public interface IService
    {
        Task<bool> CheckIfWordInDocument(string word, CancellationToken token);

        Task<string> ExtractDocumentWords(CancellationToken token);


    }
}
