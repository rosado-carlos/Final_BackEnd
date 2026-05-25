using PracticaFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaFinal.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Preguntas> Pregunta { get; set; }
        public DbSet<Respuestas> Respuesta { get; set; }
    }
}