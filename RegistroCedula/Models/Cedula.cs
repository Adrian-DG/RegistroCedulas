using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RegistroCedula.Models
{
    public class Cedula
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Byte[] Image { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Apellido { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string LugarNacimiento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public Nacionalidad GetNacionalidad { get; set; }
        [Required]
        public Sexo GetSexo { get; set; }
        [Required]
        public Sangre GetSangre { get; set; }
        [Required]
        public Estado GetEstado { get; set; }
        [Required]
        public string Ocupacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaExp { get; set; }
        [Required]
        public Provincia ProvinciaID { get; set; }
        [Required]
        public Municipio MunicipioID { get; set; }
        [Required]
        public Sector SectorID { get; set; }
        [Required]
        public Colegio ColegioID { get; set; }

        public Administrador Admin { get; set; }
    }

    public enum Nacionalidad { Dominicana, USA, Otra }
    public enum Sexo { Masculino, Femenino }
    public enum Sangre { A, B, O }
    public enum Estado { Soltero, Casado }
}