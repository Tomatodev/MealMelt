package com.tomatogaming.mealmelt;

import android.graphics.drawable.Drawable;

import java.util.List;

public class Recipe
{
    protected int Id;
    protected String Name;
    protected String Description;
    protected Author Author;
    protected Category Category;
    protected List<Recipe> Sides;
    protected List<Step> Steps;
    protected List<Ingredient> Ingredients;
    protected List<Tool> Tools;
    protected Drawable Photo;
}
