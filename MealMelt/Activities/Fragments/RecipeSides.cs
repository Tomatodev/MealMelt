using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using MealMelt.Repository;
using MealMelt.Repository.Models;
using System.Collections.Generic;
using System.IO;

namespace MealMelt.Activities.Fragments
{
    public class RecipeSides : Fragment
    {
        private readonly DatabaseContext _dbContext; //TODO: Dependency injection
        private bool _editMode;
        private List<Recipe> _sides;

        public RecipeSides(int? recipeId)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);

            if (recipeId != null)
            {
                //var side = _dbContext.Recipes.Find(recipeId);
                //_sides.Add(side);
            }
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sides, container, false);
        }
    }
}