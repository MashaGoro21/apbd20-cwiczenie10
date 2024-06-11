using System.ComponentModel.DataAnnotations;
using cwiczenie10APBD.Models;

namespace cwiczenie10APBD.DTOs;

public class NewPrescriptionDTO
{
    [Required]
    public NewPatientDTO Patient { get; set; } = null!;
    
    [Required]
    public ICollection<NewPrescriptionMedicamentDTO> Medicaments { get; set; } = null!;
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
}

public class NewPatientDTO
{
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
}

public class NewPrescriptionMedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    public string Description { get; set; }
}