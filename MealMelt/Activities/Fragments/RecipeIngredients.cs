using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using MealMelt.Repository;
using MealMelt.Repository.Models;
using System.Collections.Generic;
using System.IO;

namespace MealMelt.Activities.Fragments
{
    public class RecipeIngredients : Fragment
    {
        private readonly DatabaseContext _dbContext; //TODO: Dependency injection
        private bool _editMode;
        private List<Ingredient> _ingredients;

        public RecipeIngredients(int? recipeId)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);

            if (recipeId != null)
            {
                //var ingredient = _dbContext.Ingredients.Find(recipeId);
                //_ingredients.Add(ingredient);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_ingredients, container, false);
        }
    }
}