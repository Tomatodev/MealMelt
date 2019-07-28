using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using MealMelt.Repository;
using MealMelt.Repository.Models;
using System.Collections.Generic;
using System.IO;

namespace MealMelt.Activities.Fragments
{
    public class RecipeSteps : Fragment
    {
        private readonly DatabaseContext _dbContext; //TODO: Dependency injection
        private bool _editMode;
        private List<Step> _steps;

        public RecipeSteps(int? recipeId)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);

            if (recipeId != null)
            {
                //var step = _dbContext.Steps.Find(recipeId);
                //_steps.Add(step);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_steps, container, false);
        }
    }
}