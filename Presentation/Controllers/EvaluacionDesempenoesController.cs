using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionesDesempenoController : ControllerBase
    {
        private readonly IEvaluacionDesempenoService _evaluacionDesempenoService;

        public EvaluacionesDesempenoController(IEvaluacionDesempenoService evaluacionDesempenoService)
        {
            _evaluacionDesempenoService = evaluacionDesempenoService;
        }

        // GET: api/EvaluacionesDesempeno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluacionDesempeno>>> GetEvaluacionesDesempeno()
        {
            var evaluaciones = await _evaluacionDesempenoService.GetEvaluacionesDesempenoAsync();
            return Ok(evaluaciones);
        }

        // GET: api/EvaluacionesDesempeno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluacionDesempeno>> GetEvaluacionDesempeno(int id)
        {
            var evaluacion = await _evaluacionDesempenoService.GetEvaluacionDesempenoByIdAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return Ok(evaluacion);
        }

        // PUT: api/EvaluacionesDesempeno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacionDesempeno(int id, EvaluacionDesempeno evaluacionDesempeno)
        {
            if (id != evaluacionDesempeno.Id)
            {
                return BadRequest();
            }

            var result = await _evaluacionDesempenoService.UpdateEvaluacionDesempenoAsync(id, evaluacionDesempeno);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EvaluacionesDesempeno
        [HttpPost]
        public async Task<ActionResult<EvaluacionDesempeno>> PostEvaluacionDesempeno(EvaluacionDesempeno evaluacionDesempeno)
        {
            var nuevaEvaluacion = await _evaluacionDesempenoService.CreateEvaluacionDesempenoAsync(evaluacionDesempeno);

            return CreatedAtAction("GetEvaluacionDesempeno", new { id = nuevaEvaluacion.Id }, nuevaEvaluacion);
        }

        // DELETE: api/EvaluacionesDesempeno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacionDesempeno(int id)
        {
            var result = await _evaluacionDesempenoService.DeleteEvaluacionDesempenoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}