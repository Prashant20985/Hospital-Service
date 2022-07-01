using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Examination
    {
        [Key]
        public int ExaminationId { get; set; }

        [ForeignKey(nameof(ExaminationType))]
        public int ExaminationTypeId { get; set; }
        public ExaminationType ExaminationType { get; set; }

        public ICollection<Examination_Diagnosis> Examination_Diagnoses { get; set; } = new HashSet<Examination_Diagnosis>();


    }
}
