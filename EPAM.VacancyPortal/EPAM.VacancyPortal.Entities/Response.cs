using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int VacancyId { get; set; }
        public int EmployerId { get; set; }
    }
}
