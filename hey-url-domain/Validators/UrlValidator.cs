using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace hey_url_domain.Validators
{
    public class UrlValidator: AbstractValidator<string>
    {
        public UrlValidator()
        {
            RuleFor(s => s).Must(LinkMustBeAUri).WithMessage("Url must be a valid URI");
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return (Uri.TryCreate(link, UriKind.Absolute, out outUri)
                    && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps));
        }
    }
}
