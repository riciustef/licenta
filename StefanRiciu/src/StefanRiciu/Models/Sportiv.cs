using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Sportiv
    {
        [ScaffoldColumn(false)]
        public int ParticipantID { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        public string Localitate { get; set; }

        public string Club { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        [Display(Name = "Data de naștere")]
        public DateTime DataDeNastere { get; set; }

        public Boolean Confirmat { get; set; }

        public DateTime DataInregistrare { get; set; }

        [Display(Name = "Observații")]
        public string Observatii { get; set; }

        [Display(Name = "Categorie")]
        public int CategorieID { get; set; }

        [Display(Name = "Traseu")]
        public int TraseuID { get; set; }

        // Navigation property
        public virtual Categorie Categorii { get; set; }
        public virtual Traseu Trasee { get; set; }
    }
}
