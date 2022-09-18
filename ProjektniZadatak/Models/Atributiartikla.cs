using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjektniZadatak.Models
{
    public partial class Atributiartikla
    {
        public int Artikalid { get; set; }
        public int Vrstaatributaid { get; set; }
        [DisplayName("Vrijednost")]
        public string Vrijednostatributa { get; set; } = null!;

        public virtual Artikal Artikal { get; set; } = null!;
        public virtual Vrsteatributum Vrstaatributa { get; set; } = null!;
    }
}
