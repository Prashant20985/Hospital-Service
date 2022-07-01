using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
