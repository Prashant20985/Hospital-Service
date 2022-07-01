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
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [ForeignKey(nameof(Procedure))]
        public int ProceureId { get; set; }
        public Procedure Procedure { get; set; }

        [Required]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        [Required]
        public MedicineType MedicineType { get; set; }
    }
}
