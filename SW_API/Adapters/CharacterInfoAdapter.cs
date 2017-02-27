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
using Java.Lang;
using SW_API.Models;

namespace SW_API.Adapters
{
    class CharacterInfoAdapter :BaseAdapter<Characters>
    {
        Characters[] characters;
        Activity context;

        public CharacterInfoAdapter(Activity context, Characters[] characters): base() 
        {
            this.context = context;
            this.characters = characters;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Characters this[int position]
        {
            get { return characters[position]; }
        }
        public override int Count
        {
            get { return characters.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.CharacterInfoView, null, false);
            }
            TextView characterNameTxt = row.FindViewById<TextView>(Resource.Id.characterInfoNameTXT);
            characterNameTxt.Text = $"Name: { characters[position].Name}";

            TextView characterHeightTxt = row.FindViewById<TextView>(Resource.Id.characterHeightTXT);
            characterHeightTxt.Text = $"Height: { characters[position].Height}";

            TextView characterWeightTxt = row.FindViewById<TextView>(Resource.Id.characterWeightTXT);
            characterWeightTxt.Text = $"Mass: { characters[position].Mass}";

            return row;

        }
    }
}

