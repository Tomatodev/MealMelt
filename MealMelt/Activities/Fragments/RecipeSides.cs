using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace MealMelt.Activities.Fragments
{
    public class RecipeSides : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sides, container, false);
        }
    }
}