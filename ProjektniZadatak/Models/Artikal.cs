using System;
using System.Collections.Generic;

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
        public string Artikalsifra { get; set; } = null!;
        public string Artikalnaziv { get; set; } = null!;

        public virtual Jedinicamjere Jedinicamjere { get; set; } = null!;
        public virtual ICollection<Atributiartikla> Atributiartiklas { get; set; }
    }
}
