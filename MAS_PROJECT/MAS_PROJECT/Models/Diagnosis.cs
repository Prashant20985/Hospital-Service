using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }
        [Required,MaxLength(20)]
        public string Title { get; set; }
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();

        public ICollection<Examination_Diagnosis> Examination_Diagnoses { get; set; } = new HashSet<Examination_Diagnosis>();

    }
}
