using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeDao _employeeDao;

        public EmployeeLogic(IEmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }
    }
}
