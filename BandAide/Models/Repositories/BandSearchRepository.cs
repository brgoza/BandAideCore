using BandAide.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Repositories
{
    public class BandSearchRepository : IBandSearchRepository
    {
        private AppDbContext _context { get; }
        public BandSearchRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CreateBandSearch(BandSearch search)
        {   
            _context.BandSearches.Add(search);
            _context.SaveChanges();
            return true;
        }
        public BandSearchResults ExecuteSearch(BandSearch search)
        {
            var results = new BandSearchResults
            {
                BandSearch = search,
                BandSearchId = search.Id,
                Bands = _context.Bands.Where(b => b.MemberSearches.Select(ms => ms.InstrumentId)
                    .Contains(search.InstrumentId)).ToList()
            };
            return results;
        }
        public List<BandSearch> GetBandSearches(AppUser user)
        {
            return _context.BandSearches.Where(bs => bs.AppUserId == user.Id).ToList();
        }
    }
}
