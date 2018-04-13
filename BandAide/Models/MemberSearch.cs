using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models
{
    public class MemberSearch
    {
        [Key]
        public int Id { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; }
        public Instrument Instrument { get; set; }
        public int InstrumentId { get; set; }
        public int MinProficiency { get; set; }
        [NotMapped]
        public List<AppUser> Results { get; set; }
    }
   
}
