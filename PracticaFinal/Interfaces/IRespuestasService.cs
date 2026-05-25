using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IRespuestasService
    {
        Task<List<Respuestas>> GetAll();

        Task<Respuestas?> getById(Guid id);
        Task<Respuestas> Create(Respuestas newRespuesta);
    }
}