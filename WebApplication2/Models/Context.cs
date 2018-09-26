using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Context: DbContext
    {
        public DbSet<Aranzman> Aranzmani { get; set; }
        public DbSet<Destination> Destinacii { get; set; }
    }
}