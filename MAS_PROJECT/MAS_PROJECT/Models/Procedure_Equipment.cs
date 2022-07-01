using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Procedure_Equipment
    {
        [ForeignKey(nameof(Equipment))]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [ForeignKey(nameof(Procedure))]
        public int ProceureId { get; set; }
        public Procedure Procedure { get; set; }
    }
}
