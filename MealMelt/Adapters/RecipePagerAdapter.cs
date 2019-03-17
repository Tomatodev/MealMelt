using Android.Support.V4.App;

namespace MealMelt
{
    class RecipePagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] _fragments;

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
    }
}