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
    public class Characters
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
    }

    public class CharacterCollection
    {
        public List<Characters> results { get; set; }
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
    }
}