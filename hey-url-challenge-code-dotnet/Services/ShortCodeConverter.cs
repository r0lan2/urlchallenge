using System.Collections.Generic;
using System.Linq;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.ViewModels;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;

namespace hey_url_challenge_code_dotnet.Services
{
    public static class ShortCodeConverter
    {
        public static List<UrlResponse> ToUrlResponseList(this IEnumerable<Url> urls, string baseUrl)
        {
            return urls.Select(s => new UrlResponse()
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
