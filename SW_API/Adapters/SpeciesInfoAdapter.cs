using Android.App;
using Android.Views;
using Android.Widget;
using SW_API.Models;

namespace SW_API
{
    class SpeciesInfoAdapter : BaseAdapter<Species>
    {
        Species[] species;
        Activity context;

        public SpeciesInfoAdapter(Activity context, Species[] species) : base()
        {
            this.context = context;
            this.species = species;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Species this[int position]
        {
            get { return species[position]; }
        }
        public override int Count
        {
            get { return species.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.SpeciesInfoView, null, false);
            }
            TextView speciesNameTxt = row.FindViewById<TextView>(Resource.Id.speciesInfoNameTXT);
            speciesNameTxt.Text = $"Name: {species[position].Name}";

            TextView speciesClassTxt = row.FindViewById<TextView>(Resource.Id.speciesClassTXT);
            speciesClassTxt.Text = $"Classification: {species[position].Classification}";

            TextView speciesDesignationTxt = row.FindViewById<TextView>(Resource.Id.speciesDesignationTXT);
            speciesDesignationTxt.Text = $"Designation: {species[position].Designation}";

            TextView speciesHeightTxt = row.FindViewById<TextView>(Resource.Id.speciesHeightTXT);
            speciesHeightTxt.Text = $"Average Height: {species[position].Average_height}";

            TextView speciesSkinTxt = row.FindViewById<TextView>(Resource.Id.speciesSkinTXT);
            speciesSkinTxt.Text = $"Skin Colors: {species[position].Skin_colors}";

            TextView speciesHairTxt = row.FindViewById<TextView>(Resource.Id.speciesHairTXT);
            speciesHairTxt.Text = $"Hair Colors: {species[position].Hair_colors}";

            TextView speciesEyeTxt = row.FindViewById<TextView>(Resource.Id.speciesEyeTXT);
            speciesEyeTxt.Text = $"Eye Colors: {species[position].Eye_colors}";

            TextView speciesLifeTxt = row.FindViewById<TextView>(Resource.Id.speciesLifeTXT);
            speciesLifeTxt.Text = $"Average Lifespan: {species[position].Average_lifespan}";

            return row;

        }
    }
}

