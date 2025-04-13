namespace AIDocReader.Controller
{
    public abstract class WordRequest
    {
        public string KeyWord { get; set; }
        
    }

    public class WordResponse: WordRequest
    {
        public bool Found { get; set; }
    }
}
