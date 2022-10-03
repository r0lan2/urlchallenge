using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using HeyUrlChallengeCodeDotnet.Controllers;
using HeyUrlDomain.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using hey_url_challenge_code_dotnet;
using hey_url_challenge_code_dotnet.ViewModels;
using HeyUrlDomain.Models;

namespace hey_url_challenge_code_dotnet.Tests.Controllers
{
    public class UrlsControllerTests
    {
        protected IFixture Fixture { get; }

        public UrlsControllerTests()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Fixture.Freeze<Mock<IUrlService>>();
            Fixture.Freeze<Mock<IHttpContextAccessor>>();
            
        }

        [Fact]
        public async Task Index_Success()
        {
            var urlServiceMock = Fixture.Freeze<Mock<IUrlService>>();
            urlServiceMock.Setup(_ => _.GetUrls()).ReturnsAsync(Fixture.CreateMany<Url>());

            var httpContextAccesorMock = Fixture.Freeze<Mock<IHttpContextAccessor>>();
            var controller = new UrlsController(urlServiceMock.Object, httpContextAccesorMock.Object);
            var result = await controller.Index();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Visit_Success()
        {
            var urlServiceMock = Fixture.Freeze<Mock<IUrlService>>();
            var httpContextAccesorMock = Fixture.Freeze<Mock<IHttpContextAccessor>>();
            var fakeUrl = Fixture.Build<Url>().With(_ => _.LongUrl, "www.google.cl").Create();

            urlServiceMock.Setup(s => s.UpdateUrlClick(It.IsAny<string>())).ReturnsAsync(fakeUrl);

            var controller = new UrlsController(urlServiceMock.Object, httpContextAccesorMock.Object);
            var result = await controller.Visit("shortCode");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Show_Success()
        {
            var urlServiceMock = Fixture.Freeze<Mock<IUrlService>>();
            var httpContextAccesorMock = Fixture.Freeze<Mock<IHttpContextAccessor>>();
            var fakeUrl = Fixture.Build<Url>().With(_ => _.LongUrl, "www.google.cl").Create();

            urlServiceMock.Setup(s => s.GetUrlDetails(It.IsAny<Guid>())).ReturnsAsync(fakeUrl);

            var controller = new UrlsController(urlServiceMock.Object, httpContextAccesorMock.Object);
            var result = await controller.Show(Guid.NewGuid().ToString());
            Assert.NotNull(result);
        }


        [Fact]
        public async Task Create_Success()
        {
            var urlServiceMock = Fixture.Freeze<Mock<IUrlService>>();
            var httpContextAccesorMock = Fixture.Freeze<Mock<IHttpContextAccessor>>();
            var fakeUrl = Fixture.Build<Url>().With(_ => _.LongUrl, "www.google.cl").Create();
            var newUrl = new Url() {LongUrl = "www.emol.com"};
            var viewModel = Fixture.Build<HomeViewModel>().With(_ => _.NewUrl, newUrl).Create();


            urlServiceMock.Setup(s => s.AddNewUrl(It.IsAny<string>())).ReturnsAsync(fakeUrl);

            var controller = new UrlsController(urlServiceMock.Object, httpContextAccesorMock.Object);
            var result = await controller.Create(viewModel);
            Assert.NotNull(result);
        }


    }
}
