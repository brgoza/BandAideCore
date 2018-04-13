using BandAide.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Repositories
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private AppDbContext _context { get; }
        public InstrumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SeedInstruments()
        {
            _context.Instruments.Add(new Instrument { Name = "Piano" });
            _context.Instruments.Add(new Instrument { Name = "Guitar" });
            _context.Instruments.Add(new Instrument { Name = "Drums" });
            _context.Instruments.Add(new Instrument { Name = "Bass" });
            _context.Instruments.Add(new Instrument { Name = "Vocals" });
            _context.SaveChanges();
        }

        public List<Instrument> GetInstruments()
        {
            return _context.Instruments.ToList();
        }
        public List<Instrument> GetReaminingInstrumentsForSearch(int bandId)
        {
            var memberSearches = _context.MemberSearches.Where(ms => ms.BandId == bandId);
            var currentInstrumentIdsSearched = memberSearches.Select(ms => ms.InstrumentId);
            if (currentInstrumentIdsSearched==null)
            {
                return _context.Instruments.ToList();
            }
            return _context.Instruments.Where(i => !currentInstrumentIdsSearched.Contains(i.Id)).ToList();
        }

        public Instrument GetInstrument(int id)
        {
            return _context.Instruments.Where(i => i.Id == id).FirstOrDefault();
        }

        public Instrument GetInstrument(string name)
        {
            return _context.Instruments.Where(i => i.Name == name).FirstOrDefault();
        }
    }
}
