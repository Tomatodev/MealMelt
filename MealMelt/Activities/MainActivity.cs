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
using Android.Widget;

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

        protected override void OnResume()
        {
            FetchRecipes();
            base.OnResume();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var newRecipe = FindViewById<FloatingActionButton>(Resource.Id.newRecipeButton);
            newRecipe.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RecipeActivity));
                StartActivity(intent);
            };
        }

        private void FetchRecipes()
        {
            var recList = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new GridLayoutManager(this, 2);
            recList.SetLayoutManager(layoutManager);

            var recipes = _dbContext.Recipes.ToArray();
            var recipeAdapter = new RecipeAdapter(this, recipes);
            recList.SetAdapter(recipeAdapter);
        }

        [Export("ViewExistingRecipe")]
        public void ViewExistingRecipe(View view)
        {
            var recipeId = int.Parse(view.FindViewById<TextView>(Resource.Id.txtRecipeId).Text);
            var intent = new Intent(this, typeof(RecipeActivity));
            intent.PutExtra("RecipeId", recipeId);
            StartActivity(intent);
        }
    }
}