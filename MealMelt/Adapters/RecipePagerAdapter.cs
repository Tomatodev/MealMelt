using Android.Support.V4.App;

namespace MealMelt
{
    class RecipePagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] _fragments;
        private readonly string[] _fragmentTitles =
        {
            "Overview",
            "Ingredients",
            "Steps",
            "Sides"
        };

        public RecipePagerAdapter(FragmentManager fm, params Fragment[] fragments) : base(fm)
        {
            _fragments = fragments;
        }

        public override int Count
        {
            get
            {
                return _fragments.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            return _fragments[position];
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_fragmentTitles[position]);
        }
    }
}