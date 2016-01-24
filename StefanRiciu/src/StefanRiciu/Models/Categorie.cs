using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }

        [Required]
        public string Nume { get; set; }

        public virtual ICollection<Sportiv> Sportivi { get; set; }
    }
}
