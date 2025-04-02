namespace AIDocReader.Service
{
    public interface IService
    {
        Task<string> CheckWordInDocument(string word);
        
    }
}
