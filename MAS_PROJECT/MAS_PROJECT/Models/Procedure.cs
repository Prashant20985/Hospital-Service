using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Procedure
    {
        [Key]
        public int ProceureId { get; set; }

        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        [ForeignKey(nameof(ProcedureType))]
        public int ProcedureTypeId { get; set; }
        public ProcedureType ProcedureType { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    }
}
