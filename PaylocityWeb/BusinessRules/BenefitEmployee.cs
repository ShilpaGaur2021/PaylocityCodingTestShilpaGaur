using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityWeb.BusinessRules
{
    public class BenefitEmployee 
    {
        public Person Employee { get; set; }
        public List<Person> Dependents { get; set; }
        public BenefitEmployee(string firstName, string lastName)
        {
            Employee = new Person(firstName, lastName, true);
        }
    }
}
