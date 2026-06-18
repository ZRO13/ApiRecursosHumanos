using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // GET: api/Departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            var departamentos = await _departamentoService.GetDepartamentosAsync();
            return Ok(departamentos);
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest();
            }

            var result = await _departamentoService.UpdateDepartamentoAsync(id, departamento);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Departamentos
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            var nuevoDepartamento = await _departamentoService.CreateDepartamentoAsync(departamento);

            return CreatedAtAction("GetDepartamento", new { id = nuevoDepartamento.Id }, nuevoDepartamento);
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var result = await _departamentoService.DeleteDepartamentoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}