package com.tomatogaming.mealmelt.Model;

import java.util.List;

public class Recipe
{
    public int Id = 1;
    public String Name = "Test";
    public String Description = "Test";
    public com.tomatogaming.mealmelt.Model.Author Author;
    public com.tomatogaming.mealmelt.Model.Category Category;
    public List<Recipe> Sides;
    public List<Step> Steps;
    public List<Ingredient> Ingredients;
    public List<Tool> Tools;
    public int PhotoId;
}
