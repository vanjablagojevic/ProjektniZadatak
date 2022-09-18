using System;
using System.Collections.Generic;

namespace ProjektniZadatak.Models
{
    public partial class Jedinicamjere
    {
        public Jedinicamjere()
        {
            Artikals = new HashSet<Artikal>();
        }

        public int Jedinicamjereid { get; set; }
        public string Jedinicamjerenaziv { get; set; } = null!;
        public string Jedinicamjereskracenica { get; set; } = null!;

        public virtual ICollection<Artikal> Artikals { get; set; }
    }
}
