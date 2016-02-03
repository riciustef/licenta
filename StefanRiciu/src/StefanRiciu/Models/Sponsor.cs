using System;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Sponsor
    {
        [ScaffoldColumn(false)]
        public int SponsorID { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string URL { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Tip de sponsor")]
        public int SponsorTypeID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataInregistrare { get; set; }

        public virtual SponsorType SponsorType { get; set; }
    }
}
