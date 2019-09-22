using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.DA.DataAccesses
{
    public class CalculationDataAccess : GenericDataAccess<Calculation>, ICalculationRepository
    {
        public CalculationDataAccess(MisfitDBContext context) : base(context)
        {
        }
    }
}
