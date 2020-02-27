using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Remote { get; set; }
        public int Salary { get; set; }
        public Employer Employer { get; set; }
        public List<Skill> Requirements { get; set; }
    }
}
