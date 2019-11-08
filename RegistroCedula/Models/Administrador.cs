using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class Administrador
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}