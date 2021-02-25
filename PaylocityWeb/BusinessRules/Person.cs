using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityWeb.BusinessRules
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEligibleForDiscount { get; private set; }
        public bool IsEmployee { get; private set; }

        public Person(string firstName, string lastName, bool? isEmployee = false)
        {
            FirstName = firstName;
            LastName = lastName;
            IsEligibleForDiscount = FirstName.ToLower().StartsWith("a") || LastName.ToLower().StartsWith("a");
            IsEmployee = isEmployee ?? false;
        }
    }
}

