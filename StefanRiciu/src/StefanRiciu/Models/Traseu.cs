﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StefanRiciu.Models
{
    public class Traseu
    {
        public int TraseuID { get; set; }

        [Required]
        public string Denumire { get; set; }

        public virtual ICollection<Sportiv> Sportivi { get; set; }
    }
}
