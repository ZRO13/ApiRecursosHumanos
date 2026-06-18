using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class NominaService : INominaService
    {
        private readonly SistemaRrhhContext _context;

        public NominaService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nomina>> GetNominasAsync()
        {
            return await _context.Nominas.ToListAsync();
        }

        public async Task<Nomina?> GetNominaByIdAsync(int id)
        {
            return await _context.Nominas.FindAsync(id);
        }

        public async Task<Nomina> CreateNominaAsync(Nomina nomina)
        {
            _context.Nominas.Add(nomina);
            await _context.SaveChangesAsync();
            return nomina;
        }

        public async Task<bool> UpdateNominaAsync(int id, Nomina nomina)
        {
            _context.Entry(nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await NominaExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteNominaAsync(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return false;
            }

            _context.Nominas.Remove(nomina);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> NominaExistsAsync(int id)
        {
            return await _context.Nominas.AnyAsync(e => e.Id == id);
        }
    }
}