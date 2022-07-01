using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJECT.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Display(Name = "DoctorId")]
        public int PersonId { get; set; }
        public MedicalStaff MedicalStaff { get; set; }

        [ForeignKey(nameof(Specialization))]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public decimal calculateSalary(decimal? ratePerhour)
        {
            if (ratePerhour == null || ratePerhour == 0) return 0;

            //rate * 8 hrs a day * 20 days a month
            var estimatedSalary = ratePerhour * 8 * 20;

            return (decimal)estimatedSalary;
        }

    }
}
