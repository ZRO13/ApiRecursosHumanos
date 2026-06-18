using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IAsistenciaService
    {
        Task<IEnumerable<Asistencia>> GetAsistenciasAsync();
        Task<Asistencia?> GetAsistenciaByIdAsync(int id);
        Task<Asistencia> CreateAsistenciaAsync(Asistencia asistencia);
        Task<bool> UpdateAsistenciaAsync(int id, Asistencia asistencia);
        Task<bool> DeleteAsistenciaAsync(int id);
        Task<bool> AsistenciaExistsAsync(int id);
    }
}
