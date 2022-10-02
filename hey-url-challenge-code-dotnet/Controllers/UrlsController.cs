using System;
using System.Threading.Tasks;
using hey_url_challenge_code_dotnet;
using hey_url_challenge_code_dotnet.Services;
using hey_url_challenge_code_dotnet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        
        private readonly IUrlService _urlService;
        private readonly HttpContext _httpContext;

        public UrlsController(ILogger<UrlsController> logger, IUrlService urlService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _urlService = urlService;
            _httpContext = httpContextAccessor.HttpContext;

        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();
            
            var urls = await _urlService.GetUrls();

            model.Urls = urls.ToUrlResponseList(_httpContext.Request.GetBaseUrl());
            model.NewUrl = new();
            return View(model);
        }

        [Route("/{shortCode}")]
        public async Task<IActionResult> Visit(string shortCode)
        {
            var result =await _urlService.UpdateUrlClick(shortCode);

            return Redirect(result.LongUrl);
        }

        [Route("urls/{urlId}")]
        public async Task<IActionResult> Show(string urlId)
        {
            var result = await _urlService.GetUrlDetails(Guid.Parse(urlId));
            return View(result.ToShowViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeViewModel model)
        {
            var longUrl = model.NewUrl.LongUrl;
            await _urlService.AddNewUrl(longUrl);

            var urls = await _urlService.GetUrls();

            model.Urls = urls.ToUrlResponseList(_httpContext.Request.GetBaseUrl());
            model.NewUrl = new();

            return View("Index", model);
        }
    }
}