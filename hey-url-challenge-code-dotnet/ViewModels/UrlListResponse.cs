using System;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public class UrlListResponse
    {
        public Guid Id { get; set; }
        public string ShortCode { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int Count { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
