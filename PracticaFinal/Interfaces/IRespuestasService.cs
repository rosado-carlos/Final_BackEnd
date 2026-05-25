using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IRespuestasService
    {
        Task<List<Respuestas>> GetAll();
        Task<Respuestas> Create(Respuestas newRespuesta);
    }
}