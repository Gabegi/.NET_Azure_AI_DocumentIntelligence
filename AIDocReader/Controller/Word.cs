using System.Text.Json.Serialization;

namespace AIDocReader.Controller
{
    public class WordRequest
    {
        [JsonPropertyName("KeyWord")]

        public string KeyWord { get; set; }
        
    }


    public class WordResponse: WordRequest
    {
        [JsonPropertyName("KeyWord")]
        public string KeyWord { get; set; }


        [JsonPropertyName("Found")]
        public bool Found { get; set; }
    }
}
