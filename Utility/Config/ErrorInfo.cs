using System.Text.Json;

namespace Library.Utility.Config
{
    public class ErrorInfo
    {
        public int StatusCode { get; set; }
        public string ?ErrorMessage { get; set; }
        // public object ?Error { get; set; }
        public string ?RequestPath { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}