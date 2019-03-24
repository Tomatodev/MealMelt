using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Java.Interop;
using MealMelt.Repository.Models;

namespace MealMelt
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var recList = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new GridLayoutManager(this, 2);
            recList.SetLayoutManager(layoutManager);

            var recipes = new[] 
            {
                new Recipe { Name = "Soup", Author = "Me", PhotoId = Resource.Drawable.chefs_hat },
                new Recipe { Name = "Steak", Author = "Me" },
                new Recipe { Name = "Salad", Author = "Me", PhotoId = Resource.Drawable.chefs_hat },
                new Recipe { Name = "Stew", Author = "Me", PhotoId = Resource.Drawable.chefs_hat },
                new Recipe { Name = "Sangria", Author = "Me" },
                new Recipe { Name = "Squash", Author = "Me", PhotoId = Resource.Drawable.chefs_hat }
            };
            //TODO: populate recipes from somewhere

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