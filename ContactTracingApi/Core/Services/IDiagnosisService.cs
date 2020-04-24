using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDiagnosisService
    {
        Task<IEnumerable<Diagnosis>> GetAllDiagnoses();
        Task<Diagnosis> GetDiagnosisById(int id);
        Task<Diagnosis> AddDiagnosis(Diagnosis newDiagnosis);
        Task<Diagnosis> DeleteDiagnosis(int id);
        Task<IEnumerable<Diagnosis>> GetDiagnosesAfterDate(DateTime date);
    }
}
