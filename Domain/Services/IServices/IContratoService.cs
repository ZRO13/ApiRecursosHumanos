using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IContratoService
    {
        Task<IEnumerable<Contrato>> GetContratosAsync();
        Task<Contrato?> GetContratoByIdAsync(int id);
        Task<Contrato> CreateContratoAsync(Contrato contrato);
        Task<bool> UpdateContratoAsync(int id, Contrato contrato);
        Task<bool> DeleteContratoAsync(int id);
        Task<bool> ContratoExistsAsync(int id);
    }
}
