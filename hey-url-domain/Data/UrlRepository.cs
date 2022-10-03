using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeyUrlDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyUrlDomain.Data
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationContext _context;
        public UrlRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<Url> GetByShortUrlCode(string shortUrlCode)
        {
            return await _context.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrlCode);
        }

        public async Task<Url> GetUrlDetails(Guid id)
        {
            return await _context.Urls.Include(s=> s.Clicks).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Url>> GetAll()
        {
            return await _context.Urls.ToListAsync();
        }

        public async Task Add(Url url)
        {
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Url url)
        {
            _context.Entry(url).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
