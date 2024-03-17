using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticleDescriptions> ArticleDescriptions { get; set; }
    }
}
