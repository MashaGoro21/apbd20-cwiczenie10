using cwiczenie10APBD.DTOs;
using cwiczenie10APBD.Models;

namespace cwiczenie10APBD.Service;

public interface IMasterService
{
    Task<ICollection<Patient>> GetPatientsData(int patientId);
    Task<Patient> GetPatientById(int patientId);
    Task AddPatient(Patient patient);
    Task<Medicament> GetMedicamentById(int medicamentId);
    Task AddNewPrescription(Prescription prescription);
    Task AddPrescriptionMedicaments(IEnumerable<PrescriptionMedicament> prescriptionMedicaments);
}