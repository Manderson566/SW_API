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

namespace SW_API.Models
{
    public class Species
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string Average_height { get; set; }
        public string Skin_colors { get; set; }
        public string Hair_colors { get; set; }
        public string Eye_colors { get; set; }
        public string Average_lifespan { get; set; }
    }

    public class SpeciesCollection
    {
        public List<Species> results { get; set; }
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
    }
}