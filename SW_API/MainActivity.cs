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
        

        private ListView charactersLV;
    
        private string charDataString;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button getCharactersBTN = FindViewById<Button>(Resource.Id.getCharsBTN);
            getCharactersBTN.Click += GetCharsBTN_Click;
            




        }
        

       

        private void GetCharsBTN_Click(object sender, EventArgs e)
        {
            charDataString = GetCharacters();
            charactersLV = FindViewById<ListView>(Resource.Id.CharLV);
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charListItmes = characterCollection.results;
            CharactersAdapter adapter = new CharactersAdapter(this, charListItmes);
            charactersLV.Adapter = adapter;
            charactersLV.ItemClick += CharactersLV_ItemClick;

        }
        
        private void CharactersLV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            charDataString = GetCharacters();
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charList = characterCollection.results;
            TextView charNametxt = FindViewById<TextView>(Resource.Id.characterInfoNameTXT);
         

        // Toast.MakeText(this, $"Height: {charList[e.Position].Height} Mass: {charList[e.Position].Mass}", ToastLength.Short).Show();

        /// TextView characterNameTxt = row.FindViewById<TextView>(Resource.Id.characterNameTXT);
        //characterNameTxt.Text = listItems[position].Name;


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
    }
}

