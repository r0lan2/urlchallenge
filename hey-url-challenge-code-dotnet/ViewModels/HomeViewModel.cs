using System.Collections.Generic;
using HeyUrlDomain.Models;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<UrlResponse> Urls { get; set; }
        public Url NewUrl { get; set; }
    }
}
