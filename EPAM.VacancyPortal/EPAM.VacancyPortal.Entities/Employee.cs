using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool Relocation { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Experience { get; set; }
        public List<Skill> Skills { get; set; }

        public override string ToString()
        {
            return $"Employee. Id = {Id}.{Environment.NewLine}" + 
                $"{FirstName} {LastName}. {City}. Relocation: {Relocation}.";
        }
    }
}
