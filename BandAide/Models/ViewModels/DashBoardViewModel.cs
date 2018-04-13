using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.ViewModels
{
    public class DashBoardViewModel
    {
        public AppUser AppUser { get; set; }
        public List<Band> Bands { get; set; }
        public List<InstrumentSkill> InstrumentSkills { get; set; }
        public List<BandSearch> BandSearches { get; set; }
    }
}
