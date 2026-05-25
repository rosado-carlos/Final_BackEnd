using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFinal.Models
{
    public class Respuestas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el contenido de la respuesta")]
        [MinLength(2, ErrorMessage = "La cantidad mínima es 1")]
        public required string contenido { get; set; }
        //[ForeignKey]
        public Guid PreguntaId { get; set; }
    }
}
