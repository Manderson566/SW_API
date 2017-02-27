using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;


namespace SW_API.Models
{
    public class Planets
    {
        public string Name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
    }

    public class PlanetsCollection
    {
        public List<Planets> results { get; set; }
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
    }
}
