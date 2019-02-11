package com.tomatogaming.mealmelt;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.tomatogaming.mealmelt.Model.Recipe;

import java.util.List;

public class RecipeAdapter extends RecyclerView.Adapter<RecipeAdapter. RecipeViewHolder> {

    private List<Recipe> recipes;

    RecipeAdapter(List<Recipe> recipes) {
        this.recipes = recipes;
    }


    @Override
    public int getItemCount() {
        return recipes.size();
    }

    @Override
    public void onBindViewHolder(RecipeViewHolder recipeViewHolder, int id) {
        Recipe recipe = recipes.get(id);
        recipeViewHolder.nameView.setText(recipe.Name);
        recipeViewHolder.photoView.setImageResource(recipe.PhotoId);
    }

    @Override
    public RecipeViewHolder onCreateViewHolder(ViewGroup viewGroup, int id) {
        View itemView = LayoutInflater.
                from(viewGroup.getContext()).
                inflate(R.layout.main_cardview, viewGroup, false);

        return new RecipeViewHolder(itemView);
    }

    static class RecipeViewHolder extends RecyclerView.ViewHolder {

        TextView nameView;
        ImageView photoView;

        RecipeViewHolder(View view) {
            super(view);
            nameView = view.findViewById(R.id.txtTitle);
            photoView = view.findViewById(R.id.recipeImage);
        }
    }
}