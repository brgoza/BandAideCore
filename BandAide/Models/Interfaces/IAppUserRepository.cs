using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IAppUserRepository
    {
        AppUser GetUserByName(string userName);
        List<Band> GetMemberOfBands(AppUser user);
        List<InstrumentSkill> GetInstrumentSkills(AppUser user);
        bool IsMember(string userId, int bandId);
        bool IsAdmin(string userId, int bandId);
        
    }
}
