using Microsoft.EntityFrameworkCore;

using Unilib.Models;

namespace Unilib.DatabaseUtil
{
    public class UnilibContext : DbContext
    {
        private string _connectionString;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<BookStudent> BookStudents { get; set; }

        public UnilibContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
}
