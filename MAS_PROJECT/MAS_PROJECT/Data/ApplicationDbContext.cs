
using MAS_PROJECT.Models;
using MAS_PROJECT.Models.enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace MAS_PROJECT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalStaff> MedicalStaffs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureType> ProcedureTypes { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Procedure_Equipment> Procedure_Equipment { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Certifiation> Certifiations { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }
        public DbSet<Examination_Diagnosis> Examination_Diagnoses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
/*        public DbSet<Appointment_Nurse> Appointment_Nurses { get; set; }*/
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne(x => x.Patient)
                .WithOne(y => y.Person)
                .HasForeignKey<Patient>(z => z.PersonId);

            modelBuilder.Entity<Person>()
                .HasOne(x => x.MedicalStaff)
                .WithOne(y => y.Person)
                .HasForeignKey<MedicalStaff>(z => z.PersonId);

            modelBuilder.Entity<MedicalStaff>()
                .HasOne(x => x.Doctor)
                .WithOne(y => y.MedicalStaff)
                .HasForeignKey<Doctor>(z => z.PersonId);

            modelBuilder.Entity<MedicalStaff>()
                .HasOne(x => x.Nurse)
                .WithOne(y => y.MedicalStaff)
                .HasForeignKey<Nurse>(z => z.PersonId);

            modelBuilder.Entity<Procedure_Equipment>().HasKey(x => new { x.EquipmentId, x.ProceureId });

            modelBuilder.Entity<Examination_Diagnosis>().HasKey(x => new { x.DiagnosisId, x.ExaminationId });

            /*            modelBuilder.Entity<Appointment_Nurse>().HasKey(x => new { x.AppointmentId, x.NurseId });*/

            modelBuilder.Entity<Person>(e => e.HasData(
                new Person { PersonId = 1, FirstName = "Dawod", LastName="Ibrahim", DateOfBirth = new DateTime(2000,01,01), Gender=Gender.MALE},
                new Person { PersonId = 2, FirstName = "Osama", LastName = "Bin Laden", DateOfBirth = new DateTime(2003, 01, 04), Gender = Gender.MALE },
                new Person { PersonId = 3, FirstName = "Ali", LastName = "Awat", DateOfBirth = new DateTime(1991, 01, 05), Gender = Gender.MALE },
                new Person { PersonId = 4, FirstName = "Wafa", LastName = "Idris", DateOfBirth = new DateTime(1990, 05, 01), Gender = Gender.FEMALE },
                new Person { PersonId = 5, FirstName = "Darine", LastName = "Abu Aisha", DateOfBirth = new DateTime(2010, 01, 09), Gender = Gender.FEMALE },
                new Person { PersonId = 6, FirstName = "Munni", LastName = "Badnaam", DateOfBirth = new DateTime(2000, 07, 09), Gender = Gender.MALE }
                ));

            modelBuilder.Entity<Diagnosis>(e => e.HasData(
                new Diagnosis { DiagnosisId = 1, Title = "Kemo"},
                new Diagnosis { DiagnosisId = 2, Title = "ECG"}
                ));

            modelBuilder.Entity<Patient>(e => e.HasData(
                new Patient { PersonId = 1, InsuranceNumber = 123654, DiagnosisId = 1},
                new Patient { PersonId = 2, InsuranceNumber = 124578, DiagnosisId = 2}
                ));

            modelBuilder.Entity<MedicalStaff>(e => e.HasData(
                new MedicalStaff {PersonId = 3, RatePerHour = 10.2M },
                new MedicalStaff {PersonId = 4, RatePerHour = 12.6M },
                new MedicalStaff {PersonId = 5, RatePerHour = 14.6M },
                new MedicalStaff {PersonId = 6, RatePerHour = 12.5M }
                ));

            modelBuilder.Entity<Specialization>(e => e.HasData(
                new Specialization { SpecializationId = 1, Title = "Heart"},
                new Specialization { SpecializationId = 2, Title = "Brain"}
                ));

            modelBuilder.Entity<Doctor>(e => e.HasData(
                new Doctor { PersonId = 3, SpecializationId = 1},
                new Doctor { PersonId = 4, SpecializationId = 2}
                ));

            modelBuilder.Entity<Certifiation>(e => e.HasData(
                new Certifiation {CertificationId = 1, Title = "Dhoop" },
                new Certifiation {CertificationId = 2, Title = "Batti" }
                ));

            modelBuilder.Entity<Nurse>(e => e.HasData(
                new Nurse { PersonId = 5, CertificationId=1},
                new Nurse { PersonId = 6, CertificationId=2}
                ));

            modelBuilder.Entity<Treatment>(e => e.HasData(
                new Treatment {TreatmentId = 1, Title = "Main", DiagnosisId = 1 },
                new Treatment { TreatmentId  = 2, Title = "Secondry", DiagnosisId = 2}
                ));

            modelBuilder.Entity<ProcedureType>(e => e.HasData(
                new ProcedureType {ProcedureTypeId = 1, Title = "Dont Know" },
                new ProcedureType {ProcedureTypeId = 2, Title = "Dont Care" }
                )) ;

            modelBuilder.Entity<Equipment>(e => e.HasData(
                new Equipment { EquipmentId = 1, Title = "Surgery", Price = 1000},
                new Equipment { EquipmentId = 2, Title = "PostMortem", Price = 10.2 }
                ));

            modelBuilder.Entity<Room>(e => e.HasData(
                new Room {RoomId =1 , RoomNumber = "1230" },
                new Room {RoomId =2 , RoomNumber = "1234" }
                ));

            modelBuilder.Entity<Appointment>(e => e.HasData(
                new Appointment {AppointmentId = 1, StartTime = new DateTime(2022,01,01,10,30,00), EndTime = new DateTime(2022,01,01,11,30,00),DoctorId = 3, RoomId = 1, Status = Status.BOOKED },
                new Appointment { AppointmentId = 2, StartTime = new DateTime(2023, 05, 07, 12, 30, 00,00), EndTime = new DateTime(2023, 05, 07, 13, 30, 00), DoctorId = 4, RoomId = 2, Status = Status.AVAILABLE }
                ));

            modelBuilder.Entity<Procedure>(e => e.HasData(
                new Procedure {ProcedureTypeId = 1, TreatmentId = 1, ProceureId = 1, AppointmentId = 1 },
                new Procedure { ProcedureTypeId = 2, TreatmentId = 2, ProceureId = 2, AppointmentId = 2 }
                )) ;

            modelBuilder.Entity<Procedure_Equipment>(e => e.HasData(
                new Procedure_Equipment { EquipmentId = 1, ProceureId = 1 },
                new Procedure_Equipment { EquipmentId = 2, ProceureId = 2 }
                )); 

            modelBuilder.Entity<Medicine>(e => e.HasData(
                new Medicine { MedicineId = 1, ProceureId = 1, Amount = 10, MedicineType = MedicineType.CAPSULE},
                new Medicine { MedicineId = 2, ProceureId = 2, Amount = 5, MedicineType = MedicineType.LIQUID}
                ));

            modelBuilder.Entity<ExaminationType>(e => e.HasData(
                new ExaminationType { ExaminationTypeId = 1, Title = "Full" },
                new ExaminationType { ExaminationTypeId = 2, Title = "Partial" }
                ));

            modelBuilder.Entity<Examination>(e => e.HasData(
                new Examination { ExaminationId = 1, ExaminationTypeId = 1},
                new Examination { ExaminationId =2, ExaminationTypeId = 2}
                ));

            modelBuilder.Entity<Examination_Diagnosis>(e => e.HasData(
                new Examination_Diagnosis { ExaminationId = 1, DiagnosisId = 1 },
                new Examination_Diagnosis { ExaminationId = 2, DiagnosisId = 2 }
                ));
        }
    }
}
