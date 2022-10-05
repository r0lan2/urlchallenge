using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using hey_url_domain.Model;
using hey_url_domain.Services;
using hey_url_domain.Validators;
using HeyUrlDomain.Data;
using HeyUrlDomain.Models;
using Microsoft.EntityFrameworkCore;
using Shyjus.BrowserDetection;

namespace HeyUrlDomain.Services
{
    public class UrlService : IUrlService
    {

        private readonly IUrlRepository _repository;
        private readonly IShortUrlService _shortUrlService;
        private readonly IBrowserDetector _browserDetector;
        private readonly UrlValidator _validator;

        public UrlService(IShortUrlService shortUrlService, IUrlRepository repoRepository, IBrowserDetector browserDetector, UrlValidator validator)
        {
            _shortUrlService = shortUrlService;
            _repository = repoRepository;
            _browserDetector = browserDetector;
            _validator= validator;
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
            if (urlItem == null)
                return null;

            urlItem.Count++;
            urlItem.Clicks.Add(new UrlClick(){BrowserName = _browserDetector?.Browser?.Name, ClickDate = DateTime.Now.ToUniversalTime(), OsName = _browserDetector?.Browser?.OS});
            await _repository.Update(urlItem);
            return urlItem;
        }

        public async Task<UrlCreationResponse> AddNewUrl(string longUrl)
        {
            var response = new UrlCreationResponse();
            var result = await _validator.ValidateAsync(longUrl);

            if (!result.IsValid)
            {
                response.SetValidationsWhenValidationsAreNotOk(result);
                return response;
            }

            var shortUrl = _shortUrlService.GetUrl();
            Url url = new Url()
            {
                Count = 0,
                CreateDateTime = DateTime.UtcNow,
                ShortUrl = shortUrl,
                LongUrl = longUrl
            };
            await _repository.Add(url);
            response.Url = url;

            return response;
        }
    }
}
