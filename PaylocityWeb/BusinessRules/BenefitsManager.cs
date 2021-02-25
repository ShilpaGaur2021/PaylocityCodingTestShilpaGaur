using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PaylocityWeb.BusinessRules
{
    public class BenefitsManager : IBenefitsManager
    {
        public const decimal PayAmount = 2000.00m;
        public const int PayPeriods = 26;
        public const decimal EmployeeBenefitsCostPerYear = 1000.00m;
        public const decimal DependentBenefitsCostPerYear = 500.00m;

        public BenefitsCostResult costResult = new BenefitsCostResult();

        private decimal ApplyDiscount(decimal cost)
        {

            return cost * .9m;

        }

        private decimal GetBenefitsCost(Person person)
        {
            decimal result = 0.0m;

            try
            {
                result = person.IsEmployee ? EmployeeBenefitsCostPerYear : DependentBenefitsCostPerYear;

                if (person.IsEligibleForDiscount)
                {
                    result = ApplyDiscount(result);
                }
            }
            catch (Exception)
            {
                result = -1.0m;
                throw;
            }

            return result;

        }

        public decimal GetEmployeeCostPerPayPeriod(decimal benefitsCost)
        {
            decimal totalCostPerPayPeriod = 0.0m;

            try
            {
                decimal benefitsCostPerPayPeriod = Math.Round(benefitsCost / PayPeriods, 2);

                totalCostPerPayPeriod = PayAmount - benefitsCostPerPayPeriod;
            }
            catch (Exception)
            {
                totalCostPerPayPeriod = -1.0m;
                throw;
            }

            return totalCostPerPayPeriod;
        }

        public decimal GetEmployeeCostPerYear(decimal benefitsCostPerYear)
        {
            decimal totalCostPerYear = 0.0m;

            try
            {
                decimal totalPay = Math.Round(PayAmount * PayPeriods, 2);

                totalCostPerYear = totalPay - benefitsCostPerYear;
            }
            catch (Exception)
            {
                throw;
            }

            return totalCostPerYear;
        }

        public decimal GetTotalBenefitsCostsForEmployee(BenefitEmployee employeeData)
        {
            decimal cost = 0.0m;

            try
            {
                cost = GetBenefitsCost(employeeData.Employee);

                costResult.BenefitCostForEmployeeOnly = cost;

                if (employeeData.Dependents != null && employeeData.Dependents.Count > 0)
                {
                    foreach (var dependent in employeeData.Dependents)
                    {
                        costResult.BenefitCostForDependentsOnly += GetBenefitsCost(dependent);
                    }
                }

                cost += costResult.BenefitCostForDependentsOnly;
            }
            catch (Exception)
            {
                cost = -1.0m;
                throw;
            }

            return cost;
        }

        public BenefitsCostResult GetEmployeeCost(BenefitEmployee employeeData)
        {
            try
            {
                costResult.TotalBenefitsCostPerYear = GetTotalBenefitsCostsForEmployee(employeeData);
                costResult.TotalEmployeeCostPerPayPeriod = GetEmployeeCostPerPayPeriod(costResult.TotalBenefitsCostPerYear);
                costResult.TotalEmployeeCostPerYear = GetEmployeeCostPerYear(costResult.TotalBenefitsCostPerYear);
            }
            catch (Exception ex)
            {
                costResult.ErrorDetails = ex.Message;
            }

            return costResult;
        }

    }
}
