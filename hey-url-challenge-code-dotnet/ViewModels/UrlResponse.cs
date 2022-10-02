using System;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public class UrlResponse
    {
        public Guid Id { get; set; }
        public string ShortCode { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int Count { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
