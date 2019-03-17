using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using MealMelt.Repository.Models;
using Square.Picasso;

namespace MealMelt
{
    class RecipeAdapter : RecyclerView.Adapter //https://blog.xamarin.com/recyclerview-highly-optimized-collections-for-android-apps/
    {
        Recipe[] recipes;
        Activity activity;

        public RecipeAdapter(Activity activity, Recipe[] recipes)
        {
            this.recipes = recipes;
            this.activity = activity;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.main_cardview;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new RecipeAdapterViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = recipes[position];
            
            // Replace the contents of the view with that element
            var holder = viewHolder as RecipeAdapterViewHolder;
            holder.Caption.Text = $"{item.Name} by {item.Author.Name}";
            if (item.PhotoId != null)
            {
                Picasso.With(activity).Load(item.PhotoId ?? 0).Into(holder.Image);
            }
        }

        public override int ItemCount => recipes.Length;
    }
}