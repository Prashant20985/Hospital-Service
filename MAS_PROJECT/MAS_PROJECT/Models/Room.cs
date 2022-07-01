using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required, MaxLength(5)]
        public string RoomNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
