using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> GetDepartamentosAsync();
        Task<Departamento?> GetDepartamentoByIdAsync(int id);
        Task<Departamento> CreateDepartamentoAsync(Departamento departamento);
        Task<bool> UpdateDepartamentoAsync(int id, Departamento departamento);
        Task<bool> DeleteDepartamentoAsync(int id);
        Task<bool> DepartamentoExistsAsync(int id);
    }
}
