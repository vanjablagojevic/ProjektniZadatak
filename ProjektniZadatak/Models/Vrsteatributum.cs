using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjektniZadatak.Models
{
    public partial class Vrsteatributum
    {
        public Vrsteatributum()
        {
            Atributiartiklas = new HashSet<Atributiartikla>();
        }

        public int Vrstaatributaid { get; set; }
        [DisplayName("Naziv")]
        public string Vrstaatributanaziv { get; set; } = null!;

        public virtual ICollection<Atributiartikla> Atributiartiklas { get; set; }
    }
}
