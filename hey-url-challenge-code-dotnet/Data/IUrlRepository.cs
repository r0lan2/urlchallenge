using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hey_url_challenge_code_dotnet.Models;
using HeyUrlChallengeCodeDotnet.Data;

namespace hey_url_challenge_code_dotnet.Data
{
    public interface IUrlRepository
    {
        Task<Url> GetUrlDetails(Guid id);
        Task<Url> GetByShortUrlCode(string shortUrlCode);
        Task<Url> GetById(Guid id);
        Task<List<Url>> GetAll();
        Task Add(Url url);
        Task Update(Url url);

    }
}
