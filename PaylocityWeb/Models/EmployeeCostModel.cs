﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PaylocityWeb.Models
{
    public class EmployeeCostModel
    {
        [Display(Name = "Total Employee Benefit Cost Per Year")]
        public decimal TotalBenefitCost { get; set; }
        [Display(Name = "Employee Cost Per Pay Period")]
        public decimal EmployeeCostPerPayPeriod { get; set; }
        [Display(Name = "Employee Cost Per Year")]
        public decimal EmployeeCostPerYear { get; set; }
    }
}

