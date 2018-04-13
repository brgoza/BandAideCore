using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50,ErrorMessage = "Too long.")]
        [Remote(action:"ValidateBandName",controller:"Band")]
        public string Name { get; set; }

        public List<BandMember> BandsMembers { get; set; }
        public List<MemberSearch> MemberSearches { get; set; }
        
    }
}
