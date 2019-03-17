using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MealMelt
{
    class RecipeAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        public RecipeAdapterViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.recipeImage);
            Caption = itemView.FindViewById<TextView>(Resource.Id.txtTitle);
        }
    }
}