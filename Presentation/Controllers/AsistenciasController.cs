using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;

        public AsistenciasController(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asistencia>>> GetAsistencia()
        {
            var asistencias = await _asistenciaService.GetAsistenciasAsync();
            return Ok(asistencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asistencia>> GetAsistencia(int id)
        {
            var asistencia = await _asistenciaService.GetAsistenciaByIdAsync(id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return Ok(asistencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencia(int id, Asistencia asistencia)
        {
            if (id != asistencia.Id)
            {
                return BadRequest();
            }

            var result = await _asistenciaService.UpdateAsistenciaAsync(id, asistencia);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Asistencia>> PostAsistencia(Asistencia asistencia)
        {
            var nuevaAsistencia = await _asistenciaService.CreateAsistenciaAsync(asistencia);

            return CreatedAtAction("GetAsistencia", new { id = nuevaAsistencia.Id }, nuevaAsistencia);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencia(int id)
        {
            var result = await _asistenciaService.DeleteAsistenciaAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}