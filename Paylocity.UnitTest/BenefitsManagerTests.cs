using System;
using System.Collections.Generic;
using NUnit.Framework;
using PaylocityWeb.BusinessRules;

namespace PaylocityBenefitsChallenge.Tests
{
    [TestFixture]
    public class BenefitsManagerTests
    {

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeOnly()
        {
            BenefitEmployee employee = new BenefitEmployee("John", "Doe");

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(1000.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeOnlyWithDiscount()
        {
            BenefitEmployee employee = new BenefitEmployee("Aaron", "Smith");

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(900.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithOneDependentNoDiscount()
        {
            BenefitEmployee employee = new BenefitEmployee("Sarah", "Sharma");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bill", "Jones"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(1500.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithOneDependentBothDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee("Anna", "Das");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Andy", "Kirk"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(1350.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithFiveDependentsNoDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee("George", "Main");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bob", "Main"));
            employee.Dependents.Add(new Person("Billy", "Main"));
            employee.Dependents.Add(new Person("Susan", "Main"));
            employee.Dependents.Add(new Person("Mary", "Main"));
            employee.Dependents.Add(new Person("Frank", "Main"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(3500.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithFiveDependentsWithDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee("Mohan", "D");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bob", ""));
            employee.Dependents.Add(new Person("Allen", "D"));
            employee.Dependents.Add(new Person("Alice", "D"));
            employee.Dependents.Add(new Person("Mary", "D"));
            employee.Dependents.Add(new Person("Frank", "D"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetTotalBenefitsCostsForEmployee(employee);

            Assert.That(result, Is.EqualTo(3400.00m));

            return;
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriod()
        {
            decimal benefitsCost = 1000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.That(result, Is.EqualTo(2038.46m));
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriodUsingZeroCost()
        {
            decimal benefitsCost = 0.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.That(result, Is.EqualTo(2000.00m));
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriodUsingHighCost()
        {
            decimal benefitsCost = 8000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.That(result, Is.EqualTo(2000.00m));
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerYear()
        {
            decimal benefitsCost = 1000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerYear(benefitsCost);

            Assert.That(result, Is.EqualTo(53000.00m));
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerYearZeroBenefitsCost()
        {
            decimal benefitsCost = 0.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerYear(benefitsCost);

            Assert.That(result, Is.EqualTo(52000.00m));
        }

        [Test, Explicit]
        public void Test_GetTotalEmployeeCostData()
        {
            var employee = new BenefitEmployee("test", "person");
            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("dependent", "one"));
            employee.Dependents.Add(new Person("dependent", "two"));
            employee.Dependents.Add(new Person("dependent", "three"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCost(employee);

            Assert.That(result, Is.EqualTo(52000.00m));
        }
    }
}