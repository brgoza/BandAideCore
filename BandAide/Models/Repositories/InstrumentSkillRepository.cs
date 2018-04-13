using BandAide.Models.Interfaces;
using BandAide.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Repositories
{
    public class InstrumentSkillRepository : IInstrumentSkillRepository
    {
        private AppDbContext _context { get; }
        private IInstrumentRepository _instrumentRepo { get; }

        public InstrumentSkillRepository(AppDbContext context, IInstrumentRepository instrumentRepo)
        {
            _context = context;
            _instrumentRepo = instrumentRepo;
        }

        public List<InstrumentSkill> GetInstrumentSkills(AppUser user)
        {
            return _context.InstrumentSkills.Where(iskill => iskill.AppUserId == user.Id).ToList();
        }

        public InstrumentSkill AddInstrumentSkill(CreateInstrumentSkillViewModel vm)
        {
            if (ValidateInstrumentSkill(vm.InstrumentId, vm.AppUserId) == true)
            {
                var iSkill = new InstrumentSkill
                {
                    AppUserId = vm.AppUserId,
                    Instrument = _instrumentRepo.GetInstrument(vm.InstrumentId),
                    Proficiency = vm.Proficiency
                };

                _context.InstrumentSkills.Add(iSkill);
                _context.SaveChanges();
                return iSkill;
            }
            return null;
        }
        public bool ValidateInstrumentSkill(int instrumentId, string appUserId)
        {
            if (_context.InstrumentSkills
                .FirstOrDefault(iSkill => iSkill.InstrumentId == instrumentId && iSkill.AppUserId == appUserId) == null)
            {
                return true;
            }
            return false;
        }
    }
}
