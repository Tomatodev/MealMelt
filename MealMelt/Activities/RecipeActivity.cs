using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using MealMelt.Activities.Fragments;

namespace MealMelt
{
    [Activity(Label = "RecipeActivity")]
    public class RecipeActivity : FragmentActivity
    {
        //https://docs.microsoft.com/en-us/xamarin/android/user-interface/controls/view-pager/viewpager-and-fragments
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_recipe);

            int? recipeId = Intent.GetIntExtra("RecipeId", 0);
            if (recipeId == 0)
            {
                recipeId = null;
            }

            var adapter = new RecipePagerAdapter(SupportFragmentManager,
                    new RecipeOverview(recipeId), 
                    new RecipeIngredients(recipeId), 
                    new RecipeSteps(recipeId),
                    new RecipeSides(recipeId));
            var viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.OffscreenPageLimit = 4;
            viewPager.Adapter = adapter;
        }
    }
}