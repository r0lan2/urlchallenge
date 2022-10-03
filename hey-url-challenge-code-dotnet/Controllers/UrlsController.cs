using System;
using System.Threading.Tasks;
using hey_url_challenge_code_dotnet;
using hey_url_challenge_code_dotnet.Services;
using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrlDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly IUrlService _urlService;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UrlsController(IUrlService urlService, IHttpContextAccessor httpContextAccessor)
        {
            _urlService = urlService;
            _httpContextAccesor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();
            
            var urls = await _urlService.GetUrls();

            model.Urls = urls.ToUrlResponseList(_httpContextAccesor.GetBaseUrl());
            model.NewUrl = new();
            return View(model);
        }

        [Route("/{shortCode}")]
        public async Task<IActionResult> Visit(string shortCode)
        {
            var result =await _urlService.UpdateUrlClick(shortCode);

           return result == null ? BadRequest(): Redirect(result.LongUrl);
        }

        [Route("urls/{urlId}")]
        public async Task<IActionResult> Show(string urlId)
        {
            var result = await _urlService.GetUrlDetails(Guid.Parse(urlId));

            return result == null? BadRequest(): View(result.ToShowViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeViewModel model)
        {
            
            var result = await _urlService.AddNewUrl(model?.NewUrl?.LongUrl);
            if (result == null)
                return BadRequest();

            var urls = await _urlService.GetUrls();

            model.Urls = urls.ToUrlResponseList(_httpContextAccesor.GetBaseUrl());
            model.NewUrl = new();

            return View("Index", model);
        }
    }
}