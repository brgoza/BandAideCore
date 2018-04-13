using BandAide.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BandAide.Models.Repositories
{
    public class MemberSearchRepository : IMemberSearchRepository
    {
        private AppDbContext _context { get; }
        public MemberSearchRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreateSearch(MemberSearch search)
        {
            _context.MemberSearches.Add(search);
            _context.SaveChanges();
            return true;
        }
        public List<MemberSearch> GetCurrentSearches(Band band)
        {
            return _context.MemberSearches.Include(x=>x.Instrument).Where(ms => ms.Band == band).ToList();
        }
        public List<AppUser> ExecuteSearch(MemberSearch search)
        {
            var users = _context.Users.Include(u => u.BandSearches);
            return users
                .Where(u => u.BandSearches.Select(bs => bs.InstrumentId).Contains( search.InstrumentId)).ToList();
        }
    }
}
