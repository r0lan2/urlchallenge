using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hey_url_domain.Model
{
    public class ResponseBase
    {
        public bool IsOk { get; set; } = true;
        public List<string> ValidationErrors { get; set; }
    }
}
