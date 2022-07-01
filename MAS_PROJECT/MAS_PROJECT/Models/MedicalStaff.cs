using System;
using System.ComponentModel.DataAnnotations;


namespace MAS_PROJECT.Models
{
    public class MedicalStaff
    {
        [Key]
        [Display(Name = "MedicalStaffID")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999.99, ErrorMessage = "Invalid Target Rate; Max 6 digits")]
        public decimal RatePerHour { get; set; }

        public Doctor Doctor { get; set; }
        public Nurse Nurse { get; set; }

        public void createMedicalStaff(MedicalStaff medicalStaff)
        {
            if (medicalStaff == null) return;

            PersonId = medicalStaff.PersonId;
            RatePerHour = medicalStaff.RatePerHour;
        }

        public decimal calculateSalary(decimal? ratePerhour)
        {
            if (ratePerhour == null || ratePerhour == 0) return 0;

            //rate * 8 hrs a day * 20 days a month
            var estimatedSalary = ratePerhour * 8 * 20;

            return (decimal)estimatedSalary;
        }

    }
}
