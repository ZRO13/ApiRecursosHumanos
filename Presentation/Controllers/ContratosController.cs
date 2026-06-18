using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly IContratoService _contratoService;

        public ContratosController(IContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        // GET: api/Contratos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            var contratos = await _contratoService.GetContratosAsync();
            return Ok(contratos);
        }

        // GET: api/Contratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _contratoService.GetContratoByIdAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // PUT: api/Contratos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return BadRequest();
            }

            var result = await _contratoService.UpdateContratoAsync(id, contrato);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Contratos
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            var nuevoContrato = await _contratoService.CreateContratoAsync(contrato);

            return CreatedAtAction("GetContrato", new { id = nuevoContrato.Id }, nuevoContrato);
        }

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            var result = await _contratoService.DeleteContratoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}