using CodeConf.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeConf.Api.Database
{
    public class ConferenceContext : DbContext
    {
        public ConferenceContext(DbContextOptions<ConferenceContext> options)
            : base(options)
        { }

        public DbSet<Speaker> Speakers { get; set; }
        
        public DbSet<Talk> Talks { get; set; }
    }
}