namespace AIDocReader.Controller
{
    public abstract class WordRequest
    {
        public string keyWord { get; set; }
        
    }

    public class WordResponse: WordRequest
    {
        public bool Found { get; set; }
    }
}
