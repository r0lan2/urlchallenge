using HeyUrlDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyUrlDomain.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}