package com.tomatogaming.mealmelt;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

public class RecipeViewHolder extends RecyclerView.ViewHolder
{
    protected TextView RecipeName;
    protected ImageView RecipePhoto;

    public RecipeViewHolder(View view)
    {
        super(view);
        RecipePhoto = view.findViewById(R.id.recipeImage);
        RecipeName = view.findViewById(R.id.recipeTitle);
    }
}
