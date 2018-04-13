using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.Interfaces
{
    public interface IInstrumentRepository
    {
        void SeedInstruments();
        List<Instrument> GetInstruments();
        List<Instrument> GetReaminingInstrumentsForSearch(int bandId);
        Instrument GetInstrument(int Id);
        Instrument GetInstrument(string name);

    }
}
