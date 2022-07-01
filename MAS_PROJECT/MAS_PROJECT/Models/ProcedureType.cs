using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class ProcedureType
    {
        [Key]
        public int ProcedureTypeId { get; set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
    }
}
