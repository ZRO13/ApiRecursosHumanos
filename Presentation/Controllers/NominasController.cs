using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominasController : ControllerBase
    {
        private readonly INominaService _nominaService;

        public NominasController(INominaService nominaService)
        {
            _nominaService = nominaService;
        }

        // GET: api/Nominas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nomina>>> GetNominas()
        {
            var nominas = await _nominaService.GetNominasAsync();
            return Ok(nominas);
        }

        // GET: api/Nominas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nomina>> GetNomina(int id)
        {
            var nomina = await _nominaService.GetNominaByIdAsync(id);

            if (nomina == null)
            {
                return NotFound();
            }

            return Ok(nomina);
        }

        // PUT: api/Nominas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomina(int id, Nomina nomina)
        {
            if (id != nomina.Id)
            {
                return BadRequest();
            }

            var result = await _nominaService.UpdateNominaAsync(id, nomina);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Nominas
        [HttpPost]
        public async Task<ActionResult<Nomina>> PostNomina(Nomina nomina)
        {
            var nuevaNomina = await _nominaService.CreateNominaAsync(nomina);

            return CreatedAtAction("GetNomina", new { id = nuevaNomina.Id }, nuevaNomina);
        }

        // DELETE: api/Nominas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomina(int id)
        {
            var result = await _nominaService.DeleteNominaAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}