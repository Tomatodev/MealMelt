using MealMelt.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMelt.Repository
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext()
        //{
        //    Database.EnsureCreated();
        //}

        public DatabaseContext(string dbPath)
        {
            DatabasePath = dbPath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        private string DatabasePath { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}
