namespace AIDocReader.Service
{
    public interface IService
    {
        Task<bool> WordExistsInDocumentAsync(string filePath, string wordToSearch);
        
    }
}
