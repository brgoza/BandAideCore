using Microsoft.AspNetCore.Mvc;

namespace BandAide.Models             
{
    public class InstrumentSkill
    {
        public int Id { get; set; }

        [Remote(action: "ValidateInstrumentSkill", controller: "InstrumentSkill", AdditionalFields = nameof(InstrumentId), HttpMethod = "POST")]
        public string AppUserId { get; set; }
        public AppUser User { get; set; }

        [Remote(action: "ValidateInstrumentSkill", controller: "InstrumentSkill", AdditionalFields = nameof(AppUserId),HttpMethod ="POST")]
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int Proficiency { get; set; }
    }
}