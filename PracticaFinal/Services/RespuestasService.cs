using PracticaFinal.Interfaces;
using PracticaFinal.Models;
using PracticaFinal.Persistence;
using System.Runtime.InteropServices.Marshalling;

namespace Final.Services
{
    public class RespuestasService : IRespuestasService
    {
        private readonly ApplicationDbContext _context;
        public RespuestasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Respuestas>> GetAll()
        {
            return await _context.Pregunta.Where(e => e.estado == 1).ToListAsync();
        }

        public async Task<Respuestas?> getById(Guid id) => await _context.Respuesta.FindAsync(id);
        public async Task<Respuestas> Create(Respuestas newRespuesta)
        {
            //Agregamos el registro a la lista
            _context.Respuesta.Add(newRespuesta);
            await _context.SaveChangesAsync();
            return newRespuesta;
        }
    }
}
