using Core.Models;
using Core.Services;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly CTDbContext _context;

        public DiagnosisService(CTDbContext context)
        {
            _context = context;
        }

        public async Task<Diagnosis> AddDiagnosis(Diagnosis newDiagnosis)
        {
            await _context.Diagnosis.AddAsync(newDiagnosis);

            await _context.SaveChangesAsync();

            return newDiagnosis;
        }

        public async Task<Diagnosis> DeleteDiagnosis(int id)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(id);

            _context.Diagnosis.Remove(diagnosis);

            await _context.SaveChangesAsync();

            return diagnosis;
        }

        public async Task<IEnumerable<Diagnosis>> GetAllDiagnoses()
        {
            return await _context.Diagnosis
                .Include(d => d.DiagnosisKeys)
                .ToListAsync();
        }

        public async Task<Diagnosis> GetDiagnosisById(int id)
        {
            return await _context.Diagnosis.FindAsync(id);
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesAfterDate(DateTime date)
        {
            return await _context.Diagnosis
                .Include(d => d.DiagnosisKeys)
                .Where(d => d.Date.Date > date.Date)
                .ToListAsync();
        }
    }
}
