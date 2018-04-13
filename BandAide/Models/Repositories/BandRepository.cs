using BandAide.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BandAide.Models.Repositories
{
    public class BandRepository : IBandRepository
    {
        private AppDbContext _context { get; }

        public BandRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Band> GetBands()
        {
            return _context.Bands;
        }
        
        /// <summary>
        /// Returns the band with id = id.  Includes members and searches.
        /// </summary>
        /// <param name="id">The id of the desired user</param>
        /// <returns>A user</returns>
        public Band GetById(int id)
        {
            return _context.Bands
                .Include(b => b.BandsMembers).ThenInclude(bm=>bm.AppUser)
                .Include(b=>b.MemberSearches).ThenInclude(ms=>ms.Instrument)
                .Where(b=>b.Id==id).FirstOrDefault();
        }

        public List<AppUser> GetMembers(Band band)
        {
            var bandsMembers = _context.BandsMembers.Where(bm => bm.Band == band);
            var members = _context.Users.Where(u => bandsMembers.Select(bm => bm.AppUserId).Contains( u.Id)).ToList();
            return members;
        }

        public bool ValidateBandName(string bandName)
        {
            if (_context.Bands.Any(b => b.Name == bandName)) return false;
            return true;
        }

        public Band AddBand(Band band, AppUser creator)
        {
            _context.Bands.Add(band);
            band.BandsMembers = new List<BandMember> { new BandMember { AppUser = creator, IsAdmin = true }};
            _context.SaveChanges();
            return band;
        }

        public bool IsMember(string userId,int bandId)
        {
            return _context.BandsMembers.Any(bm => bm.AppUserId == userId && bm.BandId == bandId);
        }

        public bool IsAdmin(string userId, int bandId)
        {
            return _context.BandsMembers.Any(bm => bm.AppUserId == userId && bm.BandId == bandId && bm.IsAdmin==true);
        }
    }
}
