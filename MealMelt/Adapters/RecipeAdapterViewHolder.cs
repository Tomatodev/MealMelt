using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MealMelt
{
    class RecipeAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView RecipeId { get; set; }
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public RecipeAdapterViewHolder(View itemView) : base(itemView)
        {
            RecipeId = itemView.FindViewById<TextView>(Resource.Id.txtRecipeId);
            Image = itemView.FindViewById<ImageView>(Resource.Id.recipeImage);
            Caption = itemView.FindViewById<TextView>(Resource.Id.txtTitle);
        }
    }
}