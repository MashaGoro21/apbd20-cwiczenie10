﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cwiczenie10APBD.Data;

#nullable disable

namespace cwiczenie10APBD.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20240610131557_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cwiczenie10APBD.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "robert.brown@example.com",
                            FirstName = "Robert",
                            LastName = "Brown"
                        });
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Pain reliever",
                            Name = "Aspirin",
                            Type = "Tablet"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Antibiotic",
                            Name = "Amoxicillin",
                            Type = "Capsule"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Blood pressure medication",
                            Name = "Lisinopril",
                            Type = "Tablet"
                        });
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1973),
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1954),
                            FirstName = "Michael",
                            LastName = "Johnson"
                        },
                        new
                        {
                            IdPatient = 3,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1937),
                            FirstName = "Emma",
                            LastName = "Wilson"
                        });
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_pk");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017),
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016),
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015),
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014),
                            IdDoctor = 3,
                            IdPatient = 3
                        });
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("Prescription_Medicament_pk");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "Take two tablets daily after meals",
                            Dose = 2
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "Take one capsule three times a day",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 3,
                            Details = "Take one tablet daily in the morning"
                        });
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Prescription", b =>
                {
                    b.HasOne("cwiczenie10APBD.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .IsRequired()
                        .HasConstraintName("Prescription_Doctor");

                    b.HasOne("cwiczenie10APBD.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .IsRequired()
                        .HasConstraintName("Prescription_Patient");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("cwiczenie10APBD.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .IsRequired()
                        .HasConstraintName("Prescription_Medicament_Medicament");

                    b.HasOne("cwiczenie10APBD.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .IsRequired()
                        .HasConstraintName("Prescription_Medicament_Prescription");

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("cwiczenie10APBD.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
