using System;
using System.ComponentModel.DataAnnotations;

namespace hey_url_challenge_code_dotnet.Models
{
    public class UrlClick
    {
        [Key]
        public Guid UserClickId { get; set; }
        public string BrowserName { get; set; }
        public string OsName { get; set; }
        public DateTime ClickDate { get; set; }

        public Url Url { get; set; }

    }
}
