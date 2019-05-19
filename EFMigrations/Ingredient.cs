using System.ComponentModel.DataAnnotations;

namespace MealMelt.Repository.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } //chopped, minced, etc
        public decimal Amount { get; set; }
        public string Unit { get; set; } //cups, Tsp, etc
        public string Name { get; set; }
    }
}