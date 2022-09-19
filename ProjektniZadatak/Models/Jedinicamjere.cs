using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjektniZadatak.Models
{
    public partial class Jedinicamjere
    {
        public Jedinicamjere()
        {
            Artikals = new HashSet<Artikal>();
        }

        public int Jedinicamjereid { get; set; }
        [Display(Name = "Jedinica mjere ")]
        public string Jedinicamjerenaziv { get; set; } = null!;
        [Display(Name = "Oznaka")]
        public string Jedinicamjereskracenica { get; set; } = null!;
        public virtual ICollection<Artikal> Artikals { get; set; }
    }
}
