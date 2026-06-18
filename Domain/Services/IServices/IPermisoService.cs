using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IPermisoService
    {
        Task<IEnumerable<Permiso>> GetPermisosAsync();
        Task<Permiso?> GetPermisoByIdAsync(int id);
        Task<Permiso> CreatePermisoAsync(Permiso permiso);
        Task<bool> UpdatePermisoAsync(int id, Permiso permiso);
        Task<bool> DeletePermisoAsync(int id);
        Task<bool> PermisoExistsAsync(int id);
    }
}
