using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    [Table("Nurse")]
    public class Nurse
    {
        [Key]
        [Display(Name = "NurseId")]
        public int PersonId { get; set; }
        public MedicalStaff MedicalStaff { get; set; }

        [ForeignKey(nameof(Certifiation))]
        public int CertificationId { get; set; }
        public Certifiation Certifiation { get; set; }

        /*        public ICollection<Appointment_Nurse> Appointment_Nurses { get; set; } = new HashSet<Appointment_Nurse>();*/
        public decimal calculateSalary(decimal? ratePerhour)
        {
            if (ratePerhour == null || ratePerhour == 0) return 0;

            //rate * 8 hrs a day * 20 days a month
            var estimatedSalary = ratePerhour * 8 * 20;

            return (decimal)estimatedSalary;
        }
    }
}
