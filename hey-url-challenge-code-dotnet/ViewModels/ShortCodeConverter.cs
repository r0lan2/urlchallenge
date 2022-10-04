using System.Collections.Generic;
using System.Linq;
using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrlDomain.Models;


namespace hey_url_challenge_code_dotnet.Services
{
    public static class ShortCodeConverter
    {
        public static List<UrlListResponse> ToUrlResponseList(this IEnumerable<Url> urls, string baseUrl)
        {
            return urls.Select(s => new UrlListResponse()
            {
                Id = s.Id,
                LongUrl = s.LongUrl,
                CreateDateTime = s.CreateDateTime,
                ShortCode = s.ShortUrl,
                ShortUrl = string.Concat(baseUrl,s.ShortUrl),
                Count = s.Count
            }).ToList();
        }
    }
}
