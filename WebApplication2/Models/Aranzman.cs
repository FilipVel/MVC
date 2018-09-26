using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Aranzman

    { 

        public int Id { get; set; }

        [Display(Name = "Price")]
        public int Cena{ get; set; }

        [Display(Name = "Number of nights")]
        public int brNok { get; set; }

        [Display(Name = "Description")]
        public string Opis { get; set; }

        public string Type { get; set; }
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; }

    }
}