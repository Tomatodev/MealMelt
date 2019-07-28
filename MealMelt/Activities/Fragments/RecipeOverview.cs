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
        private bool _editMode;
        private Recipe _recipe;

        public RecipeOverview(int? recipeId)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MealMelt.db");
            _dbContext = new DatabaseContext(dbPath);

            if (recipeId != null)
            {
                _recipe = _dbContext.Recipes.Find(recipeId);
                _editMode = false;
            }
            else
            {
                _recipe = new Recipe();
                _editMode = true;
            }
        }

        public override void SetMenuVisibility(bool menuVisible) //https://stackoverflow.com/a/48414486/
        {
            base.SetMenuVisibility(menuVisible);
            if (menuVisible == false && _editMode && Context != null)
            {
                var toast = Toast.MakeText(Context, "Changes have not been saved.", ToastLength.Long);
                toast.Show();
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_overview, container, false);

            PopulateFields(view);
            ToggleControls(view, _editMode);

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

        private void PopulateFields(View view)
        {
            var titleControl = view.FindViewById<TextView>(Resource.Id.txtTitle);
            var authorControl = view.FindViewById<TextView>(Resource.Id.txtAuthor);
            var blurbControl = view.FindViewById<TextView>(Resource.Id.txtBlurb);
            var categoryControl = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            var photoControl = view.FindViewById<ImageView>(Resource.Id.imgRecipe);

            titleControl.Text = _recipe.Name;
            authorControl.Text = _recipe.Author;
            //blurbControl.Text = _recipe.Blurb;
            //categoryControl.Selected = 
            //photoControl.SetImageDrawable = 
        }

        private void ToggleControls(View view, bool enabled) //TODO: controls do not re-enable. disabled controls have underline that looks ugly
        {
            _editMode = enabled;

            var titleControl = view.FindViewById<TextView>(Resource.Id.txtTitle);
            var authorControl = view.FindViewById<TextView>(Resource.Id.txtAuthor);
            var blurbControl = view.FindViewById<TextView>(Resource.Id.txtBlurb);
            var categoryLabel = view.FindViewById<TextView>(Resource.Id.lblCategory);
            var categoryControl = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            var photoControl = view.FindViewById<ImageView>(Resource.Id.imgRecipe);
            var saveOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnSaveOverview);
            var editOverview = view.FindViewById<FloatingActionButton>(Resource.Id.btnEditOverview);

            titleControl.Focusable = enabled;
            titleControl.Clickable = enabled;
            titleControl.FocusableInTouchMode = enabled;

            authorControl.Focusable = enabled;
            authorControl.Clickable = enabled;
            authorControl.FocusableInTouchMode = enabled;

            blurbControl.Focusable = enabled;
            blurbControl.Clickable = enabled;
            blurbControl.FocusableInTouchMode = enabled;

            photoControl.Focusable = enabled;
            photoControl.Clickable = enabled;
            photoControl.FocusableInTouchMode = enabled;

            categoryLabel.Visibility = enabled ? ViewStates.Visible : ViewStates.Gone;
            categoryControl.Visibility = enabled ? ViewStates.Visible : ViewStates.Gone;
            saveOverview.Visibility = enabled ? ViewStates.Visible : ViewStates.Gone;
            editOverview.Visibility = enabled ? ViewStates.Gone : ViewStates.Visible;
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
                _recipe.Name = titleControl.Text;
                _recipe.Author = authorControl.Text;
                    //Category = _dbContext.Categories.Find(categoryControl.Id)
                _dbContext.Update(_recipe);
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