using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleadosAsync();
        Task<Empleado?> GetEmpleadoByIdAsync(int id);
        Task<Empleado> CreateEmpleadoAsync(Empleado empleado);
        Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado);
        Task<bool> DeleteEmpleadoAsync(int id);
        Task<bool> EmpleadoExistsAsync(int id);
    }
}
