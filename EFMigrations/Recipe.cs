using System.ComponentModel.DataAnnotations;

namespace MealMelt.Repository.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public int? PhotoId { get; set; }
    }
}