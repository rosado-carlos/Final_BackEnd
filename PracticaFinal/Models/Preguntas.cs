using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFinal.Models
{
    public class Preguntas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el enunciado de la pregunta")]
        [MinLength(2, ErrorMessage = "La cantidad mínima es 1")]
        public string enunciado { get; set; }
        public string categoria { get; set; }
        public int estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
