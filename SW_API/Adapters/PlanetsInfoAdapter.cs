using System;
using Android.App;
using Android.Views;
using Android.Widget;
using SW_API.Models;


namespace SW_API.Adapters
{
    class PlanetsInfoAdapter : BaseAdapter<Planets>
    {
        Planets[] planets;
        Activity context;

        public PlanetsInfoAdapter(Activity context, Planets[] planets) : base()
        {
            this.context = context;
            this.planets = planets;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Planets this[int position]
        {
            get { return planets[position]; }
        }
        public override int Count
        {
            get { return planets.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.PlanetsInfoView, null, false);
            }
            TextView planetsNameTxt = row.FindViewById<TextView>(Resource.Id.planetsInfoNameTXT);
            planetsNameTxt.Text = $"Name: {planets[position].Name}";

            TextView planetsRotationTxt = row.FindViewById<TextView>(Resource.Id.planetsRotationTXT);
            planetsRotationTxt.Text = $"Rotation Period: {planets[position].rotation_period}";

            TextView planetsOrbitalTxt = row.FindViewById<TextView>(Resource.Id.planetsOrbitalTXT);
            planetsOrbitalTxt.Text = $"Orbital Period: {planets[position].orbital_period}";

            TextView planetsDiameterTxt = row.FindViewById<TextView>(Resource.Id.planetsDiameterTXT);
            planetsDiameterTxt.Text = $"Diameter: {planets[position].diameter}";

            TextView planetsClimateTxt = row.FindViewById<TextView>(Resource.Id.planetsClimateTXT);
            planetsClimateTxt.Text = $"Climate: {planets[position].climate}";

            TextView planetsGravityTxt = row.FindViewById<TextView>(Resource.Id.planetsGravityTXT);
            planetsGravityTxt.Text = $"Gravity: {planets[position].gravity}";

            TextView planetsTerrainTxt = row.FindViewById<TextView>(Resource.Id.planetsTerrainTXT);
            planetsTerrainTxt.Text = $"Terrain: {planets[position].terrain}";

            TextView planetsSurfaceTxt = row.FindViewById<TextView>(Resource.Id.planetsSurfaceTXT);
            planetsSurfaceTxt.Text = $"Surface Water: {planets[position].surface_water}";

            TextView planetsPopulationTxt = row.FindViewById<TextView>(Resource.Id.planetsPopulationTXT);
            planetsPopulationTxt.Text = $"Population: {planets[position].population}";

            return row;

        }
    }
}
