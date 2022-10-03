using System;
using System.ComponentModel.DataAnnotations;

namespace HeyUrlDomain.Models
{
    public class UrlClick
    {
        [Key]
        public Guid UserClickId { get; set; }
        public string BrowserName { get; set; }
        public string OsName { get; set; }
        public DateTime ClickDate { get; set; }

    }
}
