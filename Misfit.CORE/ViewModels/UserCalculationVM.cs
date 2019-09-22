using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.ViewModels
{
    public class UserCalculationVM
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Num1 { get; set; }
        public string Num2 { get; set; }
        public string Sum { get; set; }
    }
}
