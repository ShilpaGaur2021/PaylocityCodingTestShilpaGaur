using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaylocityWeb.BusinessRules
{
    public class BenefitsCostResult
    {
        public BenefitEmployee EmployeeData { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal BenefitCostForEmployeeOnly { get; internal set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal BenefitCostForDependentsOnly;
        [DisplayFormat(DataFormatString = "{0:C2}")]

        public decimal TotalBenefitsCostPerYear { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalEmployeeCostPerPayPeriod { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalEmployeeCostPerYear { get; internal set; }

        public string ErrorDetails;
    }
}
