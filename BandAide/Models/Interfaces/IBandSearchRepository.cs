using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IBandSearchRepository
    {
        bool CreateBandSearch(BandSearch search);
        BandSearchResults ExecuteSearch(BandSearch search);
        List<BandSearch> GetBandSearches(AppUser user);
    }
}
