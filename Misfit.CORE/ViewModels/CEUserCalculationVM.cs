using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misfit.CORE.ViewModels
{
    public class CEUserCalculationVM
    {
        public long UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^-?\d*\.?\d*", ErrorMessage = "Invalid Number")]
        public string Num1 { get; set; }
        [Required]
        [RegularExpression(@"^-?\d*\.?\d*", ErrorMessage = "Invalid Number")]
        public string Num2 { get; set; }
        public string Sum { get; set; }
    }
}
