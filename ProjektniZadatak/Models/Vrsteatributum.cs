using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjektniZadatak.Models
{
    public partial class Vrsteatributum
    {
        public Vrsteatributum()
        {
            Atributiartiklas = new HashSet<Atributiartikla>();
        }

        public int Vrstaatributaid { get; set; }
        [Display(Name = "Vrsta atributa")]
        public string Vrstaatributanaziv { get; set; } = null!;

        public virtual ICollection<Atributiartikla> Atributiartiklas { get; set; }
    }
}
