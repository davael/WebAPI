using System;
using System.ComponentModel.DataAnnotations;

namespace APITienda.Models.DTOs
{
    public class PersonaDto
    {
        public int Id { get; set; }
        
        [Required]
        public string TipoDoc { get; set; }
        
        [Required]
        public string NroDoc { get; set; }
        
        [Required]
        public string Apellido { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public DateTime FechaNacimiento { get; set; }
        
        [Required]
        public char Sexo { get; set; }
    }
}
