using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL
{
    public class CommonLogic : ICommonLogic
    {
        private IAdminDao _adminDao;
        private IEmployerDao _employerDao;
        private IEmployeeDao _employeeDao;

        public CommonLogic(IAdminDao adminDao, IEmployerDao employerDao, IEmployeeDao employeeDao)
        {
            _adminDao = adminDao;
            _employerDao = employerDao;
            _employeeDao = employeeDao;
        }

        public bool CheckLogin(string login)
        {
            return _adminDao.SelectByLogin(login) == null
                && _employerDao.SelectByLogin(login) == null
                && _employeeDao.SelectByLogin(login) == null;
        }
    }
}
