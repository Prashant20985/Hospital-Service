using MAS_PROJECT.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Max Length is 30")]
        public string FirstName { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Max Length is 30")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        [Required]
        public Gender Gender { get; set; }
        public Patient Patient { get; set; }
        public MedicalStaff MedicalStaff { get; set; }

        public void changePersonData(Person person)
        {
            if(person == null)
            {
                return;
            }

            FirstName = person.FirstName;
            LastName = person.LastName;
            DateOfBirth = person.DateOfBirth;
            Gender = person.Gender;
        }

        public void addPatient(Patient patient)
        {
            if (patient == null) return;

            Patient.PersonId = patient.PersonId;
            Patient.InsuranceNumber = patient.InsuranceNumber;
        }

        public void addMedical(MedicalStaff medicalStaff)
        {
            if (medicalStaff == null) return;

            MedicalStaff.PersonId = medicalStaff.PersonId;
            medicalStaff.RatePerHour = medicalStaff.RatePerHour;
        }
    }
}
