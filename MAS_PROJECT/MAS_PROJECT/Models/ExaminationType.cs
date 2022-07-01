using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class ExaminationType
    {
        [Key]
        public int ExaminationTypeId { get; set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        public ICollection<Examination> Examinations { get; set; } = new HashSet<Examination>();

    }
}
