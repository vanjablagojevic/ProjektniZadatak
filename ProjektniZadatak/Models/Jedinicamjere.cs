using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjektniZadatak.Models
{
    public partial class Jedinicamjere
    {
        public Jedinicamjere()
        {
            Artikals = new HashSet<Artikal>();
        }

        public int Jedinicamjereid { get; set; }
        [DisplayName("Naziv")]
        public string Jedinicamjerenaziv { get; set; } = null!;
        [DisplayName("Oznaka")]
        public string Jedinicamjereskracenica { get; set; } = null!;

        public virtual ICollection<Artikal> Artikals { get; set; }
    }
}
