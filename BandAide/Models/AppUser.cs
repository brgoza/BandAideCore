using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Enter the abbreviation")]
        public string StateAbbr { get; set; }
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$")]
        public string Zip { get; set; }

        public List<BandMember> BandsMembers { get; set; }
        public List<InstrumentSkill> InstrumentSkills { get; set; }
        public List<BandSearch> BandSearches { get; set; }

    }
}
