using System.Collections.Generic;
using SW_API.Models;

namespace SW_API
{
    internal class SpeciesAdapter
    {
        private MainActivity mainActivity;
        private List<Characters> speciesListItmes;

        public SpeciesAdapter(MainActivity mainActivity, List<Characters> speciesListItmes)
        {
            this.mainActivity = mainActivity;
            this.speciesListItmes = speciesListItmes;
        }
    }
}