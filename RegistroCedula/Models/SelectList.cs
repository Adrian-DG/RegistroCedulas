using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroCedula.Models
{
    public class SelectList
    {
        [Key]
        public string Key { get; set; }
        public string Display { get; set; }
    }
}