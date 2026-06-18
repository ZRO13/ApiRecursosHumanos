using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface INominaService
    {
        Task<IEnumerable<Nomina>> GetNominasAsync();
        Task<Nomina?> GetNominaByIdAsync(int id);
        Task<Nomina> CreateNominaAsync(Nomina nomina);
        Task<bool> UpdateNominaAsync(int id, Nomina nomina);
        Task<bool> DeleteNominaAsync(int id);
        Task<bool> NominaExistsAsync(int id);
    }
}
