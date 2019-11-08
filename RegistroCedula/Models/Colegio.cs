using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class Colegio
    {
        [Key]
        public int ColegioID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public Sector GetSector { get; set; }
    }
}