using System;
using Microsoft.AspNetCore.Http;

namespace hey_url_challenge_code_dotnet
{
    public static class HttpRequestExtensions
    {
        public static string GetBaseUrl(this IHttpContextAccessor accessor)
        {
            if (accessor?.HttpContext?.Request == null || string.IsNullOrWhiteSpace(accessor?.HttpContext?.Request?.Scheme) || string.IsNullOrWhiteSpace(accessor?.HttpContext?.Request?.Host.Host))
                return null;

            var request = accessor?.HttpContext?.Request;


            var uriBuilder = new UriBuilder(request.Scheme, request.Host.Host, request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }

            return uriBuilder.Uri.AbsoluteUri;

        }

    }
}
