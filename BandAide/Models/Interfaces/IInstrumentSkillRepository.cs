using BandAide.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IInstrumentSkillRepository
    {
       InstrumentSkill AddInstrumentSkill(CreateInstrumentSkillViewModel vm);
        bool ValidateInstrumentSkill(int instrumentId, string appUserId);
        
    }
}
