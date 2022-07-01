using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    public class Certifiation
    {
        [Key]
        public int CertificationId { get; set; }
        [Required,MaxLength(20)]
        public string Title { get; set; }
        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
    }
}
