using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class SponsorType
    {
        public int SponsorTypeID { get; set; }

        [Required]
        public string Nume { get; set; }

        public virtual ICollection<Sponsor> Sponsori { get; set; }
    }
}
