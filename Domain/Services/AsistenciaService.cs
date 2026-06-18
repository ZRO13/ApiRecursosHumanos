using ApplicationCore.Data;
using ApplicationCore.Models;
using ApplicationCore.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly SistemaRrhhContext _context;

        public AsistenciaService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asistencia>> GetAsistenciasAsync()
        {
            return await _context.Asistencia.ToListAsync();
        }

        public async Task<Asistencia?> GetAsistenciaByIdAsync(int id)
        {
            return await _context.Asistencia.FindAsync(id);
        }

        public async Task<Asistencia> CreateAsistenciaAsync(Asistencia asistencia)
        {
            _context.Asistencia.Add(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

        public async Task<bool> UpdateAsistenciaAsync(int id, Asistencia asistencia)
        {
            _context.Entry(asistencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AsistenciaExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAsistenciaAsync(int id)
        {
            var asistencia = await _context.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return false;
            }

            _context.Asistencia.Remove(asistencia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AsistenciaExistsAsync(int id)
        {
            return await _context.Asistencia.AnyAsync(e => e.Id == id);
        }
    }
}
