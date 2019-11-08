using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public Provincia GetProvincia { get; set; }
    }
}