using System.Collections.Generic;
using SW_API.Models;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace SW_API
{
    class SpeciesAdapter : BaseAdapter<Species>
    {
        private List<Species> listItems;
        Context myContext;


        public SpeciesAdapter(Context context, List<Species> items)
        {
            listItems = items;
            myContext = context;

        }

        public override Species this[int position]
        {
            get
            {
                return listItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return listItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.SpeciesView, null, false);
            }



            TextView SpeciesNameTxt = row.FindViewById<TextView>(Resource.Id.speciesNameTXT);
            SpeciesNameTxt.Text = listItems[position].Name;

            return row;

        }
    }
}