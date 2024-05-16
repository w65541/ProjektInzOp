using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ProjektInzOp
{
    public class LibraryDbcontext : DbContext
    {
        public LibraryDbcontext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                string connString = config.GetConnectionString("AppDbConnectionString");
                optionsBuilder.UseMySql(connString,ServerVersion.AutoDetect(connString)); //Or whatever DB you are using
            }
        }


    }
}
