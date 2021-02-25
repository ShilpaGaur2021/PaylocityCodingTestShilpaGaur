using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PaylocityWeb.Models
{
    public class BenefitsModel
    {
        [Required]
        public PersonModel Employee { get; set; }

        public List<PersonModel> Dependents { get; set; }

        public BenefitsModel()
        {
            Employee = new PersonModel();
            Dependents = new List<PersonModel>();
        }

        public BenefitsModel(string firstName, string lastName)
        {
            Employee = new PersonModel() { FirstName = firstName, LastName = lastName };
            Dependents = new List<PersonModel>();
        }

    }
}
