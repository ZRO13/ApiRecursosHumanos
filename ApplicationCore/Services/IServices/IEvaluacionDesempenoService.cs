using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.IServices
{
    public interface IEvaluacionDesempenoService
    {
        Task<IEnumerable<EvaluacionDesempeno>> GetEvaluacionesDesempenoAsync();
        Task<EvaluacionDesempeno?> GetEvaluacionDesempenoByIdAsync(int id);
        Task<EvaluacionDesempeno> CreateEvaluacionDesempenoAsync(EvaluacionDesempeno evaluacionDesempeno);
        Task<bool> UpdateEvaluacionDesempenoAsync(int id, EvaluacionDesempeno evaluacionDesempeno);
        Task<bool> DeleteEvaluacionDesempenoAsync(int id);
        Task<bool> EvaluacionDesempenoExistsAsync(int id);
    }
}