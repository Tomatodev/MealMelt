package com.tomatogaming.mealmelt;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.tomatogaming.mealmelt.Model.Recipe;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //https://www.binpress.com/android-recyclerview-cardview-guide/
        RecyclerView recList = findViewById(R.id.recyclerView);
        recList.setHasFixedSize(true);
        LinearLayoutManager llm = new LinearLayoutManager(this);
        llm.setOrientation(LinearLayoutManager.VERTICAL);
        recList.setLayoutManager(llm);

        List<Recipe> recipes = new ArrayList<>();
        Recipe testRecipe1 = new Recipe();
        testRecipe1.Name = "Test Recipe 1";
        testRecipe1.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe1);
        Recipe testRecipe2 = new Recipe();
        testRecipe2.Name = "Test Recipe 2";
        testRecipe2.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe2);
        Recipe testRecipe3 = new Recipe();
        testRecipe3.Name = "Test Recipe 3";
        testRecipe3.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe3);
        Recipe testRecipe4 = new Recipe();
        testRecipe4.Name = "Test Recipe 4";
        testRecipe4.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe4);
        Recipe testRecipe5 = new Recipe();
        testRecipe5.Name = "Test Recipe 5";
        testRecipe5.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe5);
        Recipe testRecipe6 = new Recipe();
        testRecipe6.Name = "Test Recipe 6";
        testRecipe6.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe6);
        Recipe testRecipe7 = new Recipe();
        testRecipe7.Name = "Test Recipe 7";
        testRecipe7.PhotoId = R.drawable.chefs_hat;
        recipes.add(testRecipe7);
        //TODO: populate recipes from somewhere

        RecipeAdapter recipeAdapter = new RecipeAdapter(recipes);
        recList.setAdapter(recipeAdapter);
    }
}
