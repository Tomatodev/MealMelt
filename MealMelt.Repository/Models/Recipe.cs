namespace MealMelt.Repository.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public int? PhotoId { get; set; }
    }
}