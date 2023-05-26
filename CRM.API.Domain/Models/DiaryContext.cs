
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class DiaryContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Wedo> Wedo { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<About> About { get; set; }

        public DiaryContext(DbContextOptions<DiaryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
