using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hey_url_domain.Model;
using HeyUrlDomain.Models;

namespace HeyUrlDomain.Services
{
    public interface IUrlService
    {
        Task<IEnumerable<Url>> GetUrls();
        Task<Url> GetUrlDetails(Guid id);
        Task<Url> GetUrlByCode(string shortUrlCode);
        Task<Url> UpdateUrlClick(string shortUrlCode);
        Task<UrlCreationResponse> AddNewUrl(string longUrl);
    }
}
