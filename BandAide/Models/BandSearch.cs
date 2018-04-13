using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models
{
    public class BandSearch
    {
        [Key]
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Instrument Instrument { get; set; }
        public int InstrumentId { get; set; }
        [NotMapped]
        public BandSearchResults BandSearchResults { get; set; }
    }

    public class BandSearchResults
    {
        public BandSearch BandSearch { get; set; }
        public int BandSearchId { get; set; }
        public List<Band> Bands { get; set; }
    }
}
