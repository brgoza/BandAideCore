using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models.ViewModels
{
    public class CreateInstrumentSkillViewModel
    {
        public List<Instrument> Instruments { get; set; }
        [Remote(action: "ValidateInstrumentSkill", controller: "InstrumentSkill", AdditionalFields = nameof(InstrumentId), HttpMethod = "POST")]
        public string AppUserId { get; set; }
        [Remote(action: "ValidateInstrumentSkill", controller: "InstrumentSkill", AdditionalFields = nameof(AppUserId), HttpMethod = "POST")]
        public int InstrumentId { get; set; }
        public int Proficiency { get; set; }
    }
}
