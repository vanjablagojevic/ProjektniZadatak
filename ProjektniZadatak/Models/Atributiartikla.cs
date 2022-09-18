using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektniZadatak.Models
{
    public partial class Atributiartikla
    {
        [DisplayName("Artikal")]
        public int Artikalid { get; set; }
        [DisplayName("Vrsta atributa")]
        public int Vrstaatributaid { get; set; }
        [DisplayName("Vrijednost")]
        public string Vrijednostatributa { get; set; } = null!;
        [DisplayName("Artikal")]
        public virtual Artikal Artikal { get; set; } = null!;
        [DisplayName("Vrsta atributa")]
        public virtual Vrsteatributum Vrstaatributa { get; set; } = null!;
    }
}
