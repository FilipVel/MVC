using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Destination
    {


        [Display(Name = "Destination")]
        public int Id { get; set; }

        [Display(Name = "Destination Name")]
        public string Name { get; set; }

        
        public string Country { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Picture")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Aranzman> aranzmani { get; set; }
    }
}