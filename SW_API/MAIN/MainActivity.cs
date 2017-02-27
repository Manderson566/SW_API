using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using SW_API.Models;
using SW_API.Adapters;
using System.Collections.Generic;
using Android.Views;

namespace SW_API
{
    [Activity(Label = "SW_API", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView LV;

        private string charDataString;
        private string speciesDataString;
        private string planetsDataString;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button getCharactersBTN = FindViewById<Button>(Resource.Id.getCharsBTN);
            Button getSpeciesBTN = FindViewById<Button>(Resource.Id.getSpeciesBTN);
            Button getPlanetsBTN = FindViewById<Button>(Resource.Id.getPlanetsBTN);

            getCharactersBTN.Click += GetCharsBTN_Click;
            getSpeciesBTN.Click += GetSpeciesBTN_Click;
            getPlanetsBTN.Click += GetPlanetsBTN_Click;
        }

        /////GET CHARACTERS START

        private void GetCharsBTN_Click(object sender, EventArgs e)
        {
            charDataString = GetCharacters();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charListItmes = characterCollection.results;
            CharactersAdapter adapter = new CharactersAdapter(this, charListItmes);
            LV.Adapter = adapter;

            LV.ItemClick += CharactersLV_ItemClick;

        }

        private void CharactersLV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            charDataString = GetCharacters();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charList = characterCollection.results;
            Characters[] charArray = new Characters[] { charList[e.Position] };
            CharacterInfoAdapter adapter = new CharacterInfoAdapter(this, charArray);
            LV.Adapter = adapter;
        }

        public string GetCharacters()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://swapi.co/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("people/").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;

            }
        }
        /////GET CHARACTERS END

        /////GET SPECIES START

        private void GetSpeciesBTN_Click(object sender, EventArgs e)
        {
            speciesDataString = GetSpecies();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var speciesCollection = JsonConvert.DeserializeObject<SpeciesCollection>(speciesDataString);
            var speciesListItmes =  speciesCollection.results;
            SpeciesAdapter adapter = new SpeciesAdapter(this, speciesListItmes);
            LV.Adapter = adapter;

            LV.ItemClick += SpeciesLV_ItemClick;

        }

        private void SpeciesLV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            speciesDataString = GetSpecies();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var speciesCollection = JsonConvert.DeserializeObject<SpeciesCollection>(speciesDataString);
            var speciesList = speciesCollection.results;
            Species[] speciesArray = new Species[] { speciesList[e.Position] };
            SpeciesInfoAdapter adapter = new SpeciesInfoAdapter(this, speciesArray);
            LV.Adapter = adapter;

        }

        public string GetSpecies()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://swapi.co/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("species/").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            }
        }
        /////GET SPECIES END

        /////GET PLANETS START

        private void GetPlanetsBTN_Click(object sender, EventArgs e)
        {
            planetsDataString = GetPlanets();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var planetsCollection = JsonConvert.DeserializeObject<PlanetsCollection>(planetsDataString);
            var planetsListItmes = planetsCollection.results;
            PlanetsAdapter adapter = new PlanetsAdapter(this, planetsListItmes);
            LV.Adapter = adapter;

            LV.ItemClick += PlanetsLV_ItemClick;

        }

        private void PlanetsLV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            planetsDataString = GetPlanets();
            LV = FindViewById<ListView>(Resource.Id.LV);
            var planetsCollection = JsonConvert.DeserializeObject<PlanetsCollection>(planetsDataString);
            var planetsList = planetsCollection.results;
            Planets[] planetsArray = new Planets[] { planetsList[e.Position] };
            PlanetsInfoAdapter adapter = new PlanetsInfoAdapter(this, planetsArray);
            LV.Adapter = adapter;

        }

        public string GetPlanets()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://swapi.co/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("planets/").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            }
        }
        /////GET PLANETS END
    }
}

