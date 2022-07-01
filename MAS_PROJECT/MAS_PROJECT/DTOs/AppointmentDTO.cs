using MAS_PROJECT.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomNumber { get; set; }
        public string Status { get; set; }
        public string ProcedureTitle { get; set; }
    }
}
