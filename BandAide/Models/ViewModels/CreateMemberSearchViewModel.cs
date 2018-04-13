using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.ViewModels
{
    public class CreateMemberSearchViewModel
    {
        public Band Band { get; set; }
        public int BandId { get; set; }
        public Instrument Instrument { get; set; }
        public int InstrumentId { get; set; }

        public List<Instrument> Instruments { get; set; }
    }
}
