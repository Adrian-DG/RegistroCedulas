using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class RegistroContext: DbContext
    {
        public RegistroContext(): base("name=RegistroDB")
        {

        }

        
        public DbSet<Cedula> cedulas { get; set; }
        public DbSet<Administrador> administradors { get; set; }
    }
}