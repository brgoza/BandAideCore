using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.ViewModels
{
    public class CreateBandSearchViewModel
    {
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Instrument Instrument { get; set; }
        public int InstrumentId { get; set; }


    }
}
