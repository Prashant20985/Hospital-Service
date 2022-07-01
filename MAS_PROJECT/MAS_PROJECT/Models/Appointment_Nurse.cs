/*using MAS_FINAL.Shared.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_FINAL.Shared.Models
{
    public class Appointment_Nurse
    {
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey(nameof(Nurse))]
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
    }
}
*/