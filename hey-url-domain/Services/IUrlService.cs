using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeyUrlDomain.Models;

namespace HeyUrlDomain.Services
{
    public interface IUrlService
    {
        Task<IEnumerable<Url>> GetUrls();
        Task<Url> GetUrlDetails(Guid id);
        Task<Url> GetUrlByCode(string shortUrlCode);
        Task<Url> UpdateUrlClick(string shortUrlCode);
        Task<Url> AddNewUrl(string longUrl);
    }
}
