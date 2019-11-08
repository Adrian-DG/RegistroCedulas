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

        public DbSet<Provincia> provincias { get; set; }
        public DbSet<Municipio> municipios { get; set; }
        public DbSet<Sector> sectors { get; set; }
        public DbSet<Colegio> colegios { get; set; }
        public DbSet<Cedula> cedulas { get; set; }
        public DbSet<Administrador> administradors { get; set; }
    }
}