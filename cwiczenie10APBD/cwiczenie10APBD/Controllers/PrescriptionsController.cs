using System.Transactions;
using cwiczenie10APBD.DTOs;
using cwiczenie10APBD.Models;
using cwiczenie10APBD.Service;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenie10APBD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly IMasterService _masterService;

    public PrescriptionsController(IMasterService masterService)
    {
        _masterService = masterService;
    }

    [HttpPost("prescriptions")]
    public async Task<IActionResult> AddNewPrescription(NewPrescriptionDTO newPrescriptionDto)
    {
        if (newPrescriptionDto.Medicaments.Count > 10)
        {
            return NotFound("A prescription can contain a maximum of 10 medicaments.");
        }

        if (newPrescriptionDto.DueDate < newPrescriptionDto.Date)
        {
            return NotFound("Due Date must be greater than or equal to the date.");
        }

        var patient = await _masterService.GetPatientById(newPrescriptionDto.Patient.IdPatient);
        if (patient == null)
        {
            var newPatient = new Patient()
            {
                IdPatient = newPrescriptionDto.Patient.IdPatient,
                FirstName = newPrescriptionDto.Patient.FirstName,
                LastName = newPrescriptionDto.Patient.LastName,
                BirthDate = newPrescriptionDto.Patient.BirthDate
            };
            await _masterService.AddPatient(newPatient);
        }

        var prescription = new Prescription()
        {
            IdPatient = newPrescriptionDto.Patient.IdPatient,
            IdDoctor = newPrescriptionDto.IdDoctor,
            Date = newPrescriptionDto.Date,
            DueDate = newPrescriptionDto.DueDate
        };
        

        var medicaments = new List<PrescriptionMedicament>();
        foreach (var newMedicament in newPrescriptionDto.Medicaments)
        {
            var medicament = await _masterService.GetMedicamentById(newMedicament.IdMedicament);
            if (medicament is null)
            {
                return NotFound($"Medicament with ID {newMedicament.IdMedicament} does not exist.");
            }

            medicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = medicament.IdMedicament,
                Dose = newMedicament.Dose,
                Prescription = prescription
            });
        }

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _masterService.AddNewPrescription(prescription);
            await _masterService.AddPrescriptionMedicaments(medicaments);
            
            
            scope.Complete();
        }

        return Created("api/prescriptions", new
        {
            Id = prescription.IdPrescription,
            prescription.Date,
            prescription.DueDate,
            prescription.IdPatient,
            prescription.IdDoctor
        });
    }
}


