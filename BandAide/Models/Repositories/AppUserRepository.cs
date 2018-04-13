using BandAide.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private AppDbContext _context { get; }
        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppUser GetUserByName(string userName)
        {
            return _context.Users
                .Include(u=>u.BandsMembers)
                .Include(u=>u.InstrumentSkills)
                .Include(u=>u.BandSearches)
                .Where(u => u.UserName == userName).First();
        }

        public List<Band> GetMemberOfBands(AppUser user)
        {
            return _context.Bands.Where(b => b.BandsMembers.Select(bm => bm.AppUserId).Contains(user.Id)).ToList();
        }

        public List<InstrumentSkill> GetInstrumentSkills(AppUser user)
        {
            return _context.InstrumentSkills.Include(isk=>isk.Instrument).Where(iSkill => iSkill.AppUserId == user.Id).ToList();
        }

        public bool IsMember(string userId, int bandId)
        {
            return _context.BandsMembers.Any(bm => bm.AppUserId == userId && bm.BandId == bandId);
        }

        public bool IsAdmin(string userId, int bandId)
        {
            return _context.BandsMembers.Any(bm => bm.AppUserId == userId && bm.BandId == bandId && bm.IsAdmin == true);
        }
    }
}
