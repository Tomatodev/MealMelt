using System.ComponentModel.DataAnnotations;

namespace MealMelt.Repository.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public decimal TimeInMinutes { get; set; }
        public Tool Tool { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}