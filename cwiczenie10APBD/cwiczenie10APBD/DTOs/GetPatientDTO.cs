namespace cwiczenie10APBD.DTOs;

public class GetPatientDTO
{
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }
    
    public ICollection<GetPrescriptionDTO> Prescriptions { get; set; } = null!;

}

public class GetPrescriptionDTO
{
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public ICollection<GetPrescriptionMedicamentDTO> Medicaments { get; set; } = null!;

    public GetDoctorDTO Doctor { get; set; } = null!;
}

public class GetPrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int? Dose { get; set; }
    
    public string Description { get; set; } = null!;
    
}

public class GetDoctorDTO
{
    public int IdDoctor { get; set; }
    
    public string FirstName { get; set; } = null!;
}