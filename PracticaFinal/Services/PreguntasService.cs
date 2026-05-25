using PracticaFinal.Interfaces;
using PracticaFinal.Models;
using PracticaFinal.Persistence;

namespace PracticaFinal.Services
{
    public class PreguntasService : IPreguntasService
    {
        private readonly ApplicationDbContext _context;
        public PreguntasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Preguntas>> GetAll(bool estado)
        {
            return await _context.Pregunta.Where(e => e.estado == 1).ToListAsync();
        }

        public async Task<Preguntas?> getById(Guid id) => await _context.Pregunta.FindAsync(id);

        public async Task<Preguntas> Create(Preguntas newPregunta)
        {
            //Agregamos el registro a la lista
            _context.Pregunta.Add(newPregunta);
            await _context.SaveChangesAsync();
            return newPregunta;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await getById(id);
            if (existe == null) return false;

            existe.estado = existe.estado == 1 ? 0 : 0;

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
