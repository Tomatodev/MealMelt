using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MealMelt.Repository;
using MealMelt.Repository.Models;
using System;
using System.IO;

namespace MealMelt.Activities.Fragments
{
    public class RecipeOverview : Fragment
    {
        private readonly DatabaseContext _dbContext; //TODO: Dependency injection

        public RecipeOverview()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_overview, container, false);
            ToggleControls(view, false);

            var editOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnEditOverview);
            editOverview.Click += delegate
            {
                ToggleControls(view, true);
            };

            var saveOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnSaveOverview);
            saveOverview.Click += delegate
            {
                Save(view);
            };
            
            return view;
        }

        private void ToggleControls(View view, bool enabled) //TODO: controls do not re-enable. disabled controls have underline that looks ugly
        {
            var titleControl = view.FindViewById<TextView>(Resource.Id.txtTitle);
            var authorControl = view.FindViewById<TextView>(Resource.Id.txtAuthor);
            var blurbControl = view.FindViewById<TextView>(Resource.Id.txtBlurb);
            var categoryControl = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            var photoControl = view.FindViewById<ImageView>(Resource.Id.imgRecipe);
            var saveOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnSaveOverview);
            var editOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnEditOverview);

            titleControl.Focusable = enabled;
            titleControl.Clickable = enabled;
            authorControl.Focusable = enabled;
            authorControl.Clickable = enabled;
            blurbControl.Focusable = enabled;
            blurbControl.Clickable = enabled;
            categoryControl.Focusable = enabled;
            categoryControl.Clickable = enabled;
            photoControl.Focusable = enabled;
            photoControl.Clickable = enabled;

            if (enabled)
            {
                saveOverview.SetVisibility(ViewStates.Visible);
                editOverview.SetVisibility(ViewStates.Gone);
            }
            else
            {
                saveOverview.SetVisibility(ViewStates.Gone);
                editOverview.SetVisibility(ViewStates.Visible);
            }
        }

        private void Save(View view)
        {
            var titleControl = view.FindViewById<TextView>(Resource.Id.txtTitle);
            var authorControl = view.FindViewById<TextView>(Resource.Id.txtAuthor);
            var blurbControl = view.FindViewById<TextView>(Resource.Id.txtBlurb);
            var categoryControl = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            var photoControl = view.FindViewById<ImageView>(Resource.Id.imgRecipe);

            if (Validate(titleControl) && Validate(authorControl))
            {
                //Save
                var recipe = new Recipe()
                {
                    Name = titleControl.Text,
                    Author = authorControl.Text,
                    //Category = _dbContext.Categories.Find(categoryControl.Id)
                };
                _dbContext.Add(recipe);
                _dbContext.SaveChanges();
                var toast = Toast.MakeText(Context, "Changes Saved", ToastLength.Short);
                toast.Show();

                ToggleControls(view, false);
            }
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