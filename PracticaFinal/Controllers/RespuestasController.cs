using PracticaFinal.Services;
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
    public class RespuestasController : Controller
    {
        private readonly IRespuestasService _RespuestasService;

        public RespuestasController(IRespuestasService RespuestasService)
        {
            _RespuestasService = RespuestasService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(bool estado) => Ok(await _RespuestasService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var pregunta = await _RespuestasService.getById(id);
            //Se refactoriza condicion por una operación ternaria o si corto
            return pregunta != null ? Ok(pregunta) : NotFound();
            //if (evento == null)
            //{
            //    return NotFound("No existe el evento");
            //}
            //return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Respuestas newPregunta)
        {

            var createdPregunta = await _RespuestasService.Create(newPregunta);
            return CreatedAtAction(nameof(getById), new { id = createdPregunta.id }, createdPregunta);
        }

    }
}