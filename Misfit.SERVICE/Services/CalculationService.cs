using Misfit.CORE.Domains;
using Misfit.CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.SERVICE.Services
{
    public class CalculationService : GenericService<Calculation>
    {
        public Response<string> CalculateSum(CalculateVM model)
        {
            var result = SafeExecute(() => SumOfTwo(model.Num1, model.Num2));
            return result;
        }

        public string SumOfTwo(string num1, string num2)
        {
            return Misfit.CORE.Helper.Calculation.CalculateSum(num1, num2);
        }
    }
}
