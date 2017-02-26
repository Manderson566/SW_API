using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SW_API.Models;

namespace SW_API.Adapters
{
    class CharacterInfoAdapter : BaseAdapter<Characters>
    {
        private List<Characters> listItems;
        Context myContext;

        public CharacterInfoAdapter(Context context, List<Characters> items)
        {
            listItems = items;
            myContext = context;

        }


        public override Characters this[int position]
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.CharactersView, null, false);
            }



            TextView characterNameTxt = row.FindViewById<TextView>(Resource.Id.characterNameTXT);
            characterNameTxt.Text = listItems[position].Name;

            return row;
        }
    }
}

