using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeyUrlDomain.Models;


namespace HeyUrlDomain.Data
{
    public interface IUrlRepository
    {
        Task<Url> GetUrlDetails(Guid id);
        Task<Url> GetByShortUrlCode(string shortUrlCode);
        Task<List<Url>> GetAll();
        Task Add(Url url);
        Task Update(Url url);

    }
}
