using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjektniZadatak.Models
{
    public partial class Artikal
    {
        public Artikal()
        {
            Atributiartiklas = new HashSet<Atributiartikla>();
        }

        public int Artikalid { get; set; }
        public int Jedinicamjereid { get; set; }
        [Display(Name = "Šifra artikla")]
        public string Artikalsifra { get; set; } = null!;
        [Display(Name = "Naziv artikla")]
        public string Artikalnaziv { get; set; } = null!;

        [Display(Name = "Jedinica mjere")]
        public virtual Jedinicamjere? Jedinicamjere { get; set; } 
        public virtual ICollection<Atributiartikla> Atributiartiklas { get; set; }
    }
}
