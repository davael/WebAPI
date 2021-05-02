using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITienda.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
