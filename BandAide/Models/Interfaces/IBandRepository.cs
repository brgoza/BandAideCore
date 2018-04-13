using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IBandRepository
    {
        IQueryable<Band> GetBands();
        Band GetById(int Id);
        List<AppUser> GetMembers(Band band);
        bool ValidateBandName(string bandName);
        Band AddBand(Band band, AppUser creator);
        bool IsMember(string userId, int bandId);
        bool IsAdmin(string userId, int bandId);
    }
}
