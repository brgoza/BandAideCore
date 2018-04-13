using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IMemberSearchRepository
    {
        List<MemberSearch> GetCurrentSearches(Band band);
        List<AppUser> ExecuteSearch(MemberSearch search);
        bool CreateSearch(MemberSearch search);
    }
}
