using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDiagnosisKeyService
    {
        Task<IEnumerable<DiagnosisKey>> GetLatestDiagnosisKeys();
        Task<IEnumerable<DiagnosisKey>> AddDiagnosisKeys(IEnumerable<DiagnosisKey> newDiagnosisKey);
        Task<DiagnosisKey> GetDiagnosisKeyById(int id);
        Task<DiagnosisKey> AddDiagnosisKey(DiagnosisKey newDiagnosisKey);
        Task<DiagnosisKey> DeleteDiagnosisKey(int id);
        
    }
}
