using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Examination_Diagnosis
    {
        [ForeignKey(nameof(Diagnosis))]
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        [ForeignKey(nameof(Examination))]
        public int ExaminationId { get; set; }
        public Examination Examination { get; set; }
    }
}
