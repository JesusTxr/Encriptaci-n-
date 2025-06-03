namespace CesarApi.Models
{
    public class CipherRequest
    {
        public string Message { get; set; } = string.Empty;
        public int Shift { get; set; }
        public bool Decrypt { get; set; }
    }
} 