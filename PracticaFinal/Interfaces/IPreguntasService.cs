using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IPreguntasService
    {
        Task<List<Preguntas>> GetAll(bool estado);
        Task<Preguntas?> getById(Guid id);

        Task<Preguntas> Create(Preguntas evento);

        Task<bool> ChangeStatus(Guid id);
    }
}
