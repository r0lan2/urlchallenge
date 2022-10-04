using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using HeyUrlDomain.Services;
using Xunit;

namespace hey_url_domain.Tests
{
    public class UrlServiceTests
    {
        protected IFixture Fixture { get; }
        protected UrlService Service { get; }

        public UrlServiceTests()
        {

            Fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            Service = Fixture.Create<UrlService>();
        }

        [Fact]
        public async Task GetUrls_Success()
        {
            var exception = await Record.ExceptionAsync(() => Service.GetUrls());
            Assert.Null(exception);
        }

        [Fact]
        public async Task AddNewUrl_Success()
        {
            var exception = await Record.ExceptionAsync(() => Service.AddNewUrl("google.cl"));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("badUrl")]
        [InlineData("http://")]
        [InlineData("hola.com")]
        public async Task AddNewUrl_GetWrongLongUrl_ReturnIsOk_to_False(string longUrl)
        {
            var result = await Service.AddNewUrl(longUrl);
            Assert.False(result.IsOk);
        }


        [Fact]
        public async Task GetUrlDetails_Success()
        {
            var exception = await Record.ExceptionAsync(() => Service.GetUrlDetails(Guid.NewGuid()));
            Assert.Null(exception);
        }

        [Fact]
        public async Task GetUrlByCode_Success()
        {
            var exception = await Record.ExceptionAsync(() => Service.GetUrlByCode("FDASF"));
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateUrlClick_Success()
        {
            var exception = await Record.ExceptionAsync(() => Service.UpdateUrlClick("FDASF"));
            Assert.Null(exception);
        }
    }
}
