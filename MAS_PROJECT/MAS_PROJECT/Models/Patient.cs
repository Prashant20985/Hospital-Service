using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Patient
    {
        [Key]
        [Display(Name = "PatientId")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        [Required]
        public long InsuranceNumber { get; set; }

        [ForeignKey(nameof(Diagnosis))]
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        public void createPatient(Patient patient)
        {
            if (patient == null) return;

            PersonId = patient.PersonId;
            InsuranceNumber = patient.InsuranceNumber;
        }
    }
}
