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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button getCharactersBTN = FindViewById<Button>(Resource.Id.getCharsBTN);

            getCharactersBTN.Click += GetCharsBTN_Click;
        }

        /////GET CHARACTERS START

        private void GetCharsBTN_Click(object sender, EventArgs e)
        {
            charDataString = GetCharacters();
            LV = FindViewById<ListView>(Resource.Id.CharLV);
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charListItmes = characterCollection.results;
            CharactersAdapter adapter = new CharactersAdapter(this, charListItmes);
            LV.Adapter = adapter;

            LV.ItemClick += CharactersLV_ItemClick;

        }

        private void CharactersLV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            charDataString = GetCharacters();
            LV = FindViewById<ListView>(Resource.Id.CharLV);
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
            LV = FindViewById<ListView>(Resource.Id.CharLV);
            var speciesCollection = JsonConvert.DeserializeObject<CharacterCollection>(speciesDataString);
            var speciesListItmes =  speciesCollection.results;
            SpeciesAdapter adapter = new SpeciesAdapter(this, speciesListItmes);
            LV.Adapter = adapter;

            LV.ItemClick += SpeciesLV_ItemClick;

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
    }
}

