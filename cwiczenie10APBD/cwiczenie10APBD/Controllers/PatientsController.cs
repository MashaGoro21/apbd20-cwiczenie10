using cwiczenie10APBD.DTOs;
using cwiczenie10APBD.Service;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenie10APBD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IMasterService _masterService;

    public PatientsController(IMasterService masterService)
    {
        _masterService = masterService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientsData(int patientId)
    {
        var patients = await _masterService.GetPatientsData(patientId);

        return Ok(patients.Select(e => new GetPatientDTO()
        {
            IdPatient = e.IdPatient,
            FirstName = e.FirstName,
            LastName = e.LastName,
            BirthDate = e.BirthDate,
            Prescriptions = e.Prescriptions.Select(p => new GetPrescriptionDTO
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = p.PrescriptionMedicaments.Select(k => new GetPrescriptionMedicamentDTO
                {
                    IdMedicament = k.IdMedicament,
                    Name = k.Medicament.Name,
                    Dose = k.Dose,
                    Description = k.Medicament.Description
                }).ToList(),
                
                Doctor = new GetDoctorDTO
                {
                    IdDoctor = p.Doctor.IdDoctor, 
                    FirstName = p.Doctor.FirstName
                }
                
            }).ToList()
        }));
    }
}

