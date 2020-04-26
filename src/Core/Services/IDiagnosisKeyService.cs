using VegaIT.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VegaIT.Core.Services
{
    public interface IDiagnosisKeyService
    {
        Task<IEnumerable<DiagnosisKey>> GetAllDiagnosisKeys();
        Task<IEnumerable<DiagnosisKey>> AddDiagnosisKeys(IEnumerable<DiagnosisKey> newDiagnosisKey);
        Task<DiagnosisKey> GetDiagnosisKeyById(int id);
        Task<DiagnosisKey> AddDiagnosisKey(DiagnosisKey newDiagnosisKey);
        Task<DiagnosisKey> DeleteDiagnosisKey(int id);
        
    }
}
