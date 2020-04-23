using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDiagnosisKeyService
    {
        Task<IEnumerable<DiagnosisKey>> GetAllDiagnosisKeys();
        Task<DiagnosisKey> GetDiagnosisKeyById(int id);
        Task<DiagnosisKey> AddDiagnosisKey(DiagnosisKey newDiagnosisKey);
        Task<DiagnosisKey> DeleteDiagnosisKey(int id);
        
    }
}
