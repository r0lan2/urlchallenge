using System;
using System.Collections.Generic;

namespace HeyUrlDomain.Models
{
    public class Url
    {
        public Guid Id { get; set; }

        //TODO: Rename to ShortUrlCode
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int Count { get; set; }
        public DateTime CreateDateTime { get; set; }

        public List<UrlClick> Clicks { get; set; } = new List<UrlClick>();
    }
}
