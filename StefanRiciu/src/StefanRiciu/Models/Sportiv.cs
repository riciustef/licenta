using System;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Sportiv
    {
        [ScaffoldColumn(false)]
        public int SportivID { get; set; }

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de naștere (zz-ll-aaaa)")]
        public DateTime DataDeNastere { get; set; }

        public Boolean Confirmat { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInregistrare { get; set; }

        [Display(Name = "Observații")]
        public string Observatii { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Categorie")]
        public int CategorieID { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Traseu")]
        public int TraseuID { get; set; }

        // Navigation property
        public virtual Categorie Categorie { get; set; }
        public virtual Traseu Traseu { get; set; }
    }
}
