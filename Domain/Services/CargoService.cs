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
    public class CargoService : ICargoService
    {
        private readonly SistemaRrhhContext _context;

        public CargoService(SistemaRrhhContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> GetCargosAsync()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task<Cargo?> GetCargoByIdAsync(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        public async Task<Cargo> CreateCargoAsync(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();
            return cargo;
        }

        public async Task<bool> UpdateCargoAsync(int id, Cargo cargo)
        {
            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CargoExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteCargoAsync(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return false;
            }

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CargoExistsAsync(int id)
        {
            return await _context.Cargos.AnyAsync(e => e.Id == id);
        }
    }
}
