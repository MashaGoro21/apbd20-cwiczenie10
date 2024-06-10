using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenie10APBD.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}
