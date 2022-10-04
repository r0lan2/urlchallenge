using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeyUrlDomain.Models;

namespace hey_url_domain.Model
{
    public class UrlCreationResponse: ResponseBase
    {
        public Url Url { get; set; }
    }
}
