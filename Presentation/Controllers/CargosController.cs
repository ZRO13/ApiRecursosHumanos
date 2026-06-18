using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            var cargos = await _cargoService.GetCargosAsync();
            return Ok(cargos);
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await _cargoService.GetCargoByIdAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        // PUT: api/Cargos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            var result = await _cargoService.UpdateCargoAsync(id, cargo);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Cargos
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
            var nuevoCargo = await _cargoService.CreateCargoAsync(cargo);

            return CreatedAtAction("GetCargo", new { id = nuevoCargo.Id }, nuevoCargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var result = await _cargoService.DeleteCargoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
