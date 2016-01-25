using System;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Pagina
    {
        [ScaffoldColumn(false)]
        public int PaginaID { get; set; }

        [Required]
        public string Titlu { get; set; }

        [Required]
        public string Descriere { get; set; }

        [Required]
        [Display(Name = "Conținut")]
        public string Continut { get; set; }

        public string Imagine { get; set; }
        public string Video { get; set; }

        public Boolean Activa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInregistrare { get; set; }
    }
}
