package com.tomatogaming.mealmelt;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import com.tomatogaming.mealmelt.Fragments.RecipeIngredients;
import com.tomatogaming.mealmelt.Fragments.RecipeOverview;
import com.tomatogaming.mealmelt.Fragments.RecipeSides;
import com.tomatogaming.mealmelt.Fragments.RecipeSteps;

public class TabPagerAdapter extends FragmentStatePagerAdapter {
    private int tabCount;

    TabPagerAdapter(FragmentManager fragmentManager, int tabCount) {
        super(fragmentManager);
        this.tabCount = tabCount;
    }

    //https://www.truiton.com/2015/06/android-tabs-example-fragments-viewpager/
    @Override
    public Fragment getItem(int position) {

        switch (position) {
            case 0:
                return new RecipeOverview();
            case 1:
                return new RecipeIngredients();
            case 2:
                return new RecipeSteps();
            case 3:
                return new RecipeSides();
            default:
                return null;
        }
    }

    @Override
    public int getCount() {
        return tabCount;
    }
}
