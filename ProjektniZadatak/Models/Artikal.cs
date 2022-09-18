using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjektniZadatak.Models
{
    public partial class Artikal
    {
        public Artikal()
        {
            Atributiartiklas = new HashSet<Atributiartikla>();
        }

        public int Artikalid { get; set; }

        [DisplayName("Jedinica mjere")]
        public int Jedinicamjereid { get; set; }
        [DisplayName("Šifra artikla")]
        public string Artikalsifra { get; set; } = null!;
        [DisplayName("Naziv")]
        public string Artikalnaziv { get; set; } = null!;

        [DisplayName("Jedinica mjere")]
        public virtual Jedinicamjere Jedinicamjere { get; set; } = null!;
        public virtual ICollection<Atributiartikla> Atributiartiklas { get; set; }
    }
}
