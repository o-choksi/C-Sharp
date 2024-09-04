using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceReport.Models
{
    public class FinanceModel
    {
        [Required]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Assets")]
        public decimal Assets { get; set; }

        [Required]
        [Display(Name = "Liabilities")]
        public decimal Liabilities { get; set; }

        [Required]
        [Range(18, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}
