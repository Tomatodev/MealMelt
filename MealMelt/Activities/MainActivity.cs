using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Java.Interop;
using MealMelt.Repository;
using System.Linq;
using System.IO;
using System;

namespace MealMelt
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly DatabaseContext _dbContext;

        public MainActivity()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var recList = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new GridLayoutManager(this, 2);
            recList.SetLayoutManager(layoutManager);

            var recipes = _dbContext.Recipes.ToArray(); 
            var recipeAdapter = new RecipeAdapter(this, recipes);
            recList.SetAdapter(recipeAdapter);

            var newRecipe = FindViewById<FloatingActionButton>(Resource.Id.newRecipeButton);
            newRecipe.Click += (sender, e) => {
                var intent = new Intent(this, typeof(RecipeActivity));
                StartActivity(intent);
            };
        }

        [Export("ViewExistingRecipe")]
        public void ViewExistingRecipe(View view)
        {
            var intent = new Intent(this, typeof(RecipeActivity));
            StartActivity(intent);
        }
    }
}