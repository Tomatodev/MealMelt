using System.ComponentModel.DataAnnotations;

namespace MealMelt.Repository.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDangerous { get; set; }
    }
}