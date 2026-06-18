using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PermisoService : IPermisoService
    {
        private readonly SistemaRrhhContext _context;

        public PermisoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> GetPermisosAsync()
        {
            return await _context.Permisos.ToListAsync();
        }

        public async Task<Permiso?> GetPermisoByIdAsync(int id)
        {
            return await _context.Permisos.FindAsync(id);
        }

        public async Task<Permiso> CreatePermisoAsync(Permiso permiso)
        {
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();
            return permiso;
        }

        public async Task<bool> UpdatePermisoAsync(int id, Permiso permiso)
        {
            _context.Entry(permiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PermisoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeletePermisoAsync(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return false;
            }

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PermisoExistsAsync(int id)
        {
            return await _context.Permisos.AnyAsync(e => e.Id == id);
        }
    }
}