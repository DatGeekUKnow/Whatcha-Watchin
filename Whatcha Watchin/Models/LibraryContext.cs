using Microsoft.EntityFrameworkCore;

namespace Whatcha_Watchin.Models
{
    class LibraryContext : DbContext
    {
        // Binds to Medias table
        public DbSet<Media> Watch_Later { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=library.db");
        }
    }
}
