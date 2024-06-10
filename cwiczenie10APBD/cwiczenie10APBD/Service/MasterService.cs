using cwiczenie10APBD.Data;
using cwiczenie10APBD.DTOs;
using cwiczenie10APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenie10APBD.Service;

public class MasterService : IMasterService
{
    private readonly MasterContext _context;
    public MasterService(MasterContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Patient>> GetPatientsData(int patientId)
    {
        return await _context.Patients
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.Doctor)
            .ThenInclude(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Where(e => e.IdPatient == patientId)
            .ToListAsync();
        
    }

    public async Task<Patient> GetPatientById(int patientId)
    {
        return await _context.Patients.FirstOrDefaultAsync(e => e.IdPatient == patientId);
    }

    public async Task AddPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<Medicament> GetMedicamentById(int medicamentId)
    {
        return await _context.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == medicamentId);
    }

    public async Task AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescriptionMedicaments(IEnumerable<PrescriptionMedicament> prescriptionMedicaments)
    {
        await _context.AddRangeAsync(prescriptionMedicaments);
        await _context.SaveChangesAsync();
    }
}