using MealMelt.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMelt.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DatabaseContext(string dbPath)
        {
            DatabasePath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        private string DatabasePath { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
