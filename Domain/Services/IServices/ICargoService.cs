using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface ICargoService
    {
        Task<IEnumerable<Cargo>> GetCargosAsync();
        Task<Cargo?> GetCargoByIdAsync(int id);
        Task<Cargo> CreateCargoAsync(Cargo cargo);
        Task<bool> UpdateCargoAsync(int id, Cargo cargo);
        Task<bool> DeleteCargoAsync(int id);
        Task<bool> CargoExistsAsync(int id);
    }
}
