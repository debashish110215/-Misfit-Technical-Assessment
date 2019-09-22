using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Misfit.CORE.Domains
{
    public class Calculation : BaseModel
    {
        [Required]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Number Format")]
        public string Num1 { get; set; }
        [Required]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Number Format")]
        public string Num2 { get; set; }
        [Required]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Number Format")]
        public string Sum { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
