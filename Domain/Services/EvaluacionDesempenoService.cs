using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class EvaluacionDesempenoService : IEvaluacionDesempenoService
    {
        private readonly SistemaRrhhContext _context;

        public EvaluacionDesempenoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EvaluacionDesempeno>> GetEvaluacionesDesempenoAsync()
        {
            return await _context.EvaluacionDesempenos.ToListAsync();
        }

        public async Task<EvaluacionDesempeno?> GetEvaluacionDesempenoByIdAsync(int id)
        {
            return await _context.EvaluacionDesempenos.FindAsync(id);
        }

        public async Task<EvaluacionDesempeno> CreateEvaluacionDesempenoAsync(EvaluacionDesempeno evaluacionDesempeno)
        {
            _context.EvaluacionDesempenos.Add(evaluacionDesempeno);
            await _context.SaveChangesAsync();
            return evaluacionDesempeno;
        }

        public async Task<bool> UpdateEvaluacionDesempenoAsync(int id, EvaluacionDesempeno evaluacionDesempeno)
        {
            _context.Entry(evaluacionDesempeno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EvaluacionDesempenoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteEvaluacionDesempenoAsync(int id)
        {
            var evaluacionDesempeno = await _context.EvaluacionDesempenos.FindAsync(id);
            if (evaluacionDesempeno == null)
            {
                return false;
            }

            _context.EvaluacionDesempenos.Remove(evaluacionDesempeno);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EvaluacionDesempenoExistsAsync(int id)
        {
            return await _context.EvaluacionDesempenos.AnyAsync(e => e.Id == id);
        }
    }
}