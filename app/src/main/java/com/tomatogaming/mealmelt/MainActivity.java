package com.tomatogaming.mealmelt;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

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

        List<Recipe> recipes;
        //TODO: populate recipes from somewhere

        RecipeAdapter recipeAdapter = new RecipeAdapter(recipes);
        recList.setAdapter(recipeAdapter);
    }
}
