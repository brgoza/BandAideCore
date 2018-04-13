using System.ComponentModel.DataAnnotations.Schema;

namespace BandAide.Models
{
    [Table("BandsMembers")]
    public class BandMember
    {
        public Band Band { get; set; }
        public int BandId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}