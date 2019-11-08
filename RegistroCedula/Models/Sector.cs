using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class Sector
    {
        [Key]
        public int SectorID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public Municipio GetMunicipio { get; set; }
    }
}