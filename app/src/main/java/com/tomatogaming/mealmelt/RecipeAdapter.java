package com.tomatogaming.mealmelt;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class RecipeAdapter extends RecyclerView.Adapter<RecipeAdapter.RecipeViewHolder>
{
    private List<Recipe> Recipes;

    public RecipeAdapter(List<Recipe> recipes)
    {
        this.Recipes = recipes;
    }

    @Override
    public int getItemCount()
    {
        return Recipes.size();
    }

    @Override
    public void onBindViewHolder(RecipeViewHolder recipeViewHolder, int id) {
        Recipe recipe = Recipes.get(id);
        recipeViewHolder.RecipeName.setText(recipe.Name);
        recipeViewHolder.RecipePhoto.setImageDrawable(recipe.Photo);
    }

    @Override
    public RecipeViewHolder onCreateViewHolder(ViewGroup viewGroup, int id) {
        View itemView = LayoutInflater.
                from(viewGroup.getContext()).
                inflate(R.layout.main_cardview, viewGroup, false);

        return new RecipeViewHolder(itemView);
    }

    class RecipeViewHolder extends RecyclerView.ViewHolder
    {
        TextView RecipeName;
        ImageView RecipePhoto;

        RecipeViewHolder(View view)
        {
            super(view);
            RecipePhoto = view.findViewById(R.id.recipeImage);
            RecipeName = view.findViewById(R.id.recipeTitle);
        }
    }
}
