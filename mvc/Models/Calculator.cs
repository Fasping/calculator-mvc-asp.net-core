using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Calculator
    {
        public double Operator1 { get; set; }

        public double Operator2 { get; set; }

        public string? Action { get; set; }

        [Display(Name = "The answer is :")]
        public string Answer { get; set; } = string.Empty;
    }
}
