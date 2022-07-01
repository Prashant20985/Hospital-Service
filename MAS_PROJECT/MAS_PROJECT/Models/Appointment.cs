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
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public Status Status { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
/*        public ICollection<Appointment_Nurse> Appointment_Nurses { get; set; } = new HashSet<Appointment_Nurse>();*/
    }
}
