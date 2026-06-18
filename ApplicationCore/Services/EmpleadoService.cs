using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly SistemaRrhhContext _context;

        public EmpleadoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            // Se incluyen las relaciones fuertes para la vista del frontend
            return await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Cargo)
                .ToListAsync();
        }

        public async Task<Empleado?> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Cargo)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmpleadoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return false;
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmpleadoExistsAsync(int id)
        {
            return await _context.Empleados.AnyAsync(e => e.Id == id);
        }
    }
}