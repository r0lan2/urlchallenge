using System.Text.RegularExpressions;
using HeyUrlDomain.Services;
using Xunit;

namespace hey_url_domain.Tests
{

    //TODO: Revisit regex
    public class ShortUrlServiceTests
    {
        [Theory]
        [InlineData("www.google.cl")]
        [InlineData("www.altavista.cl")]
        [InlineData("www.bing.cl")]
        [InlineData("www.uol.cl")]
        public void GetUrl_Success(string longUrl)
        {
            var regexItem = new Regex("^[A-Z0-9 ]*$");
            var service = new ShortUrlService();
            var shortCode = service.GetUrl();

            Assert.True(shortCode.ToUpper() == shortCode);
            Assert.True(shortCode.Length == 5);
            Assert.True(regexItem.IsMatch(shortCode));
        }


    }
}

