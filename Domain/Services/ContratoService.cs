using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ContratoService : IContratoService
    {
        private readonly SistemaRrhhContext _context;

        public ContratoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contrato>> GetContratosAsync()
        {
            return await _context.Contratos.ToListAsync();
        }

        public async Task<Contrato?> GetContratoByIdAsync(int id)
        {
            return await _context.Contratos.FindAsync(id);
        }

        public async Task<Contrato> CreateContratoAsync(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
            return contrato;
        }

        public async Task<bool> UpdateContratoAsync(int id, Contrato contrato)
        {
            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ContratoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteContratoAsync(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return false;
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ContratoExistsAsync(int id)
        {
            return await _context.Contratos.AnyAsync(e => e.Id == id);
        }
    }
}