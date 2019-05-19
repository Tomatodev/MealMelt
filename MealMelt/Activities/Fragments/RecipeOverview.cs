using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MealMelt.Repository;
using System.IO;

namespace MealMelt.Activities.Fragments
{
    public class RecipeOverview : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_overview, container, false);

            var titleControl = view.FindViewById<TextView>(Resource.Id.txtTitle);
            var authorControl = view.FindViewById<TextView>(Resource.Id.txtAuthor);
            var blurbControl = view.FindViewById<TextView>(Resource.Id.txtBlurb);
            var categoryControl = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            var photoControl = view.FindViewById<ImageView>(Resource.Id.imgRecipe);

            var saveOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnSaveOverview);
            saveOverview.Click += (sender, e) => 
            {
                if (Validate(titleControl) && Validate(authorControl))
                {
                    //Save
                    
                    var toast = Toast.MakeText(Context, "Changes Saved", ToastLength.Short);
                    toast.Show(); 
                }
            };

            return view;
        }

        private bool Validate(TextView control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                control.Error = $"Enter a Valid {control.HintFormatted}";
                return false;
            }
            return true;
        }
    }
}