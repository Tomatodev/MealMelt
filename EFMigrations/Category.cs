using System.ComponentModel.DataAnnotations;

namespace MealMelt.Repository.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}