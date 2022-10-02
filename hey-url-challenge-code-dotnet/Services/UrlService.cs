using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hey_url_challenge_code_dotnet.Data;
using hey_url_challenge_code_dotnet.Models;
using Shyjus.BrowserDetection;

namespace hey_url_challenge_code_dotnet.Services
{
    public class UrlService : IUrlService
    {

        private readonly IUrlRepository _repository;
        private readonly IShortUrlService _shortUrlService;
        private readonly IBrowserDetector _browserDetector;
        public UrlService(IShortUrlService shortUrlService, IUrlRepository repoRepository, IBrowserDetector browserDetector)
        {
            _shortUrlService = shortUrlService;
            _repository = repoRepository;
            _browserDetector = browserDetector;
        }

        public async Task<IEnumerable<Url>> GetUrls()
        {
            return await _repository.GetAll();
        }

        public async Task<Url> GetUrlDetails(Guid id)
        {
            return await _repository.GetUrlDetails(id);
        }

        public async Task<Url> GetUrlByCode(string shortUrlCode)
        {
            return await _repository.GetByShortUrlCode(shortUrlCode);
        }

        public async Task<Url> UpdateUrlClick(string shortUrlCode)
        {
            var urlItem = await GetUrlByCode(shortUrlCode);
            urlItem.Count++;
            urlItem.Clicks.Add(new UrlClick(){BrowserName = _browserDetector?.Browser?.Name, ClickDate = DateTime.Now.ToUniversalTime(), OsName = _browserDetector?.Browser?.OS});
            await _repository.Update(urlItem);
            return urlItem;
        }

        public async Task<Url> AddNewUrl(string longUrl)
        { 
            var shortUrl = _shortUrlService.GetUrl();
            Url url = new Url()
            {
                Count = 0,
                CreateDateTime = DateTime.UtcNow,
                ShortUrl = shortUrl,
                LongUrl = longUrl
            };
            await _repository.Add(url);
            return url;
        }
    }
}
