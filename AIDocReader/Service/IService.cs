namespace AIDocReader.Service
{
    public interface IService
    {
        Task<bool> InputCheck(string filePath, string wordToSearch);
        Task<string> CheckWordInDocument(string word, string filePath);
        
    }
}
