using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
