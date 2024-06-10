using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cwiczenie10APBD.Models;

namespace cwiczenie10APBD.Data;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("Doctor_pk");

            entity.ToTable("Doctor");

            entity.Property(e => e.IdDoctor).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.IdMedicament).HasName("Medicament_pk");

            entity.ToTable("Medicament");

            entity.Property(e => e.IdMedicament).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("Patient_pk");

            entity.ToTable("Patient");

            entity.Property(e => e.IdPatient).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.IdPrescription).HasName("Prescription_pk");

            entity.ToTable("Prescription");

            entity.Property(e => e.IdPrescription).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DueDate).HasColumnType("date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Patient");
        });

        modelBuilder.Entity<PrescriptionMedicament>(entity =>
        {
            entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("Prescription_Medicament_pk");

            entity.ToTable("Prescription_Medicament");

            entity.Property(e => e.Details).HasMaxLength(100);

            entity.HasOne(d => d.Medicament).WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Medicament_Medicament");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Medicament_Prescription");
        });
        
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor() {
                IdDoctor = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            },
            new Doctor() {
                IdDoctor = 2,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com"
            },
            new Doctor() {
                IdDoctor = 3,
                FirstName = "Robert",
                LastName = "Brown",
                Email = "robert.brown@example.com"
            }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament()
            {
                IdMedicament = 1,
                Name = "Aspirin",
                Description = "Pain reliever",
                Type = "Tablet"
            },
            new Medicament()
            {
                IdMedicament = 2,
                Name = "Amoxicillin",
                Description = "Antibiotic",
                Type = "Capsule"
            },
            new Medicament()
            {
                IdMedicament = 3,
                Name = "Lisinopril",
                Description = "Blood pressure medication",
                Type = "Tablet"
            }
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient()
            {
                IdPatient = 1,
                FirstName = "Jane",
                LastName = "Doe",
                BirthDate = new DateTime(1990-05-12)
            },
            new Patient()
            {
                IdPatient = 2,
                FirstName = "Michael",
                LastName = "Johnson",
                BirthDate = new DateTime(1985-08-23)
            },
            new Patient()
            {
                IdPatient = 3,
                FirstName = "Emma",
                LastName = "Wilson",
                BirthDate = new DateTime(1978-11-30)
            }
        });
        
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription()
            {
                IdPrescription = 1,
                Date = new DateTime(2024-06-01),
                DueDate = new DateTime(2024-06-30),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription()
            {
                IdPrescription = 2,
                Date = new DateTime(2024-06-02),
                DueDate = new DateTime(2024-07-02),
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 3,
                Date = new DateTime(2024-06-03),
                DueDate = new DateTime(2024-07-03),
                IdPatient = 3,
                IdDoctor = 3
            }
        });
        
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "Take two tablets daily after meals"
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 1,
                Details = "Take one capsule three times a day"
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Dose = null,
                Details = "Take one tablet daily in the morning"
            }
        });
            
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
