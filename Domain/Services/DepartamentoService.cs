using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly SistemaRrhhContext _context;

        public DepartamentoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> GetDepartamentoByIdAsync(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task<Departamento> CreateDepartamentoAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        public async Task<bool> UpdateDepartamentoAsync(int id, Departamento departamento)
        {
            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartamentoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return false;
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DepartamentoExistsAsync(int id)
        {
            return await _context.Departamentos.AnyAsync(e => e.Id == id);
        }
    }
}