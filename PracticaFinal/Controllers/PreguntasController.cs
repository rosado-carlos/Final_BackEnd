using Final.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // con este DataAnnotation solo se dejará ejecutar los endpoint a los JWT que sea de Admin
    // Si se quiere agregar más roles se separa por comas Admin,User,Colab
    //[Authorize(Roles = "Admin")]
    public class PreguntasController : Controller
    {
        private readonly IPreguntasService _preguntasService;

        public PreguntasController(IPreguntasService preguntasService)
        {
            _preguntasService = preguntasService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{estado}")]
        public async Task<IActionResult> GetAll(bool estado) => Ok(await _preguntasService.GetAll(estado));

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var pregunta = await _preguntasService.getById(id);
            //Se refactoriza condicion por una operación ternaria o si corto
            return pregunta != null ? Ok(pregunta) : NotFound();
            //if (evento == null)
            //{
            //    return NotFound("No existe el evento");
            //}
            //return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Preguntas newPregunta)
        {

            var createdPregunta = await _preguntasService.Create(newPregunta);
            return CreatedAtAction(nameof(getById), new { id = createdPregunta.id }, createdPregunta);
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _preguntasService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento") : NotFound();
        }

    }
}