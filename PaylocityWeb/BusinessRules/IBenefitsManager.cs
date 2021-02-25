using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PaylocityWeb.BusinessRules
{
   public interface IBenefitsManager
    {
        BenefitsCostResult GetEmployeeCost(BenefitEmployee employee);
    }
}
