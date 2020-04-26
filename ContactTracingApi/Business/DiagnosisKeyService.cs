using VegaIT.Core.Models;
using VegaIT.Core.Services;
using VegaIT.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VegaIT.Business
{
    public class DiagnosisKeyService : IDiagnosisKeyService
    {
        private readonly CTDbContext _context;
        public DiagnosisKeyService(CTDbContext context)
        {
            _context = context;
        }

        public async Task<DiagnosisKey> AddDiagnosisKey(DiagnosisKey newDiagnosisKey)
        {
            await _context.DiagnosisKeys.AddAsync(newDiagnosisKey);

            await _context.SaveChangesAsync();

            return newDiagnosisKey;
        }

        public async Task<IEnumerable<DiagnosisKey>> AddDiagnosisKeys(IEnumerable<DiagnosisKey> newDiagnosisKey)
        {
            await _context.DiagnosisKeys.AddRangeAsync(newDiagnosisKey);

            await _context.SaveChangesAsync();

            return newDiagnosisKey;
        }

        public async Task<DiagnosisKey> DeleteDiagnosisKey(int id)
        {
            var diagnosiskey = await _context.DiagnosisKeys.FindAsync(id);

            _context.DiagnosisKeys.Remove(diagnosiskey);

            await _context.SaveChangesAsync();

            return diagnosiskey;
        }

        public async Task<IEnumerable<DiagnosisKey>> GetAllDiagnosisKeys()
        {
            return await _context.DiagnosisKeys.ToListAsync();
        }

        public async Task<DiagnosisKey> GetDiagnosisKeyById(int id)
        {
            return await _context.DiagnosisKeys.FindAsync(id);
        }
    }
}
