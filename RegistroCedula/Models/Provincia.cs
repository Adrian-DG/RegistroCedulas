using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}