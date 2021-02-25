using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

using PaylocityWeb.BusinessRules;
using PaylocityWeb.Models;

namespace ShilpaGaurPaylocityBenefitsChallengeTest.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly IBenefitsManager _benefitsManager;
        public BenefitsController(IBenefitsManager benefitsManager)
        {
            _benefitsManager = benefitsManager;
        }
      

        public ActionResult Calculate()
        {
            var employee = new BenefitsModel();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Calculate(BenefitsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Calculate", model);
            }

            var benefitsEmployee = new BenefitEmployee(model.Employee.FirstName, model.Employee.LastName);

            if (model.Dependents != null && model.Dependents.Count > 0)
            {
                var dependents = new List<PaylocityWeb.BusinessRules.Person>();
                foreach (var dependent in model.Dependents)
                {
                    var employeeDependent = new Person(dependent.FirstName, dependent.LastName);
                    dependents.Add(employeeDependent);
                }

                benefitsEmployee.Dependents = dependents;
            }

            var response = _benefitsManager.GetEmployeeCost(benefitsEmployee);

            EmployeeCostModel responseModel = new EmployeeCostModel();
            responseModel.TotalBenefitCost = response.TotalBenefitsCostPerYear;
            responseModel.EmployeeCostPerPayPeriod = response.TotalEmployeeCostPerPayPeriod;
            responseModel.EmployeeCostPerYear = response.TotalEmployeeCostPerYear;

            return View("ViewEmployeeCost", responseModel);
        }


        public ActionResult AddNewDependent()
        {
            var dependent = new PersonModel();
            return PartialView("_Dependent", dependent);
        }

    }

}
