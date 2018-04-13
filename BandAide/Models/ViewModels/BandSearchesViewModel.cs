using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.ViewModels
{
    public class BandSearchesViewModel
    {
        public AppUser AppUser { get; set; }
        public Instrument PreferredInstrument { get; set; }
        public List<BandSearch> Searches { get; set; }
        

    }
}
