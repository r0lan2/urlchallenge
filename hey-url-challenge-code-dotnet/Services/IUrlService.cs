using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.ViewModels;

namespace hey_url_challenge_code_dotnet.Services
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
