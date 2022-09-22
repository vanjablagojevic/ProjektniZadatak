using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjektniZadatak.Models
{
    public partial class Atributiartikla
    {
        public int Artikalid { get; set; }
        [Display(Name = "Vrsta atributa")]
        public int Vrstaatributaid { get; set; }

        [Display(Name = "Vrijednost atributa")]
        public string Vrijednostatributa { get; set; } = null!;

        public virtual Artikal? Artikal { get; set; }
        [Display(Name = "Vrsta atributa")]
        public virtual Vrsteatributum? Vrstaatributa { get; set; } 
    }
}
