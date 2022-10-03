using System;
using System.Threading.Tasks;
using HeyUrlDomain.Data;
using HeyUrlDomain.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace hey_url_domain.Tests
{
    public class UrlRepositoryTests
    {
        private readonly UrlRepository _repository;
        public UrlRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("TestMemoryDb");
            
            var context = new ApplicationContext(builder.Options);
            context.Urls.RemoveRange(context.Urls);
            context.SaveChanges();

            _repository = new UrlRepository(context);
        }

        [Fact]
        public async Task GetUrlDetails_Success()
        {
            var result= await _repository.GetUrlDetails(Guid.NewGuid());
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByShortUrlCode_Success()
        {
            var result = await _repository.GetByShortUrlCode("thecode");
            Assert.Null(result);
        }


        [Fact]
        public async Task Add_Success()
        {
            var ex = await Record.ExceptionAsync(async () => await _repository.Add(url: new Url()
            {
                LongUrl = "google.cl",
                ShortUrl = "thecode",
                Count = 0,
                CreateDateTime = DateTime.UtcNow,
                Id = Guid.NewGuid()
            }));
            Assert.Null(ex);
        }


        [Fact]
        public async Task GetAll_Success()
        {
            var result = await _repository.GetAll();
            Assert.Empty(result);
        }
    }
}
