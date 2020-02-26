using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL
{
    public class AdminLogic : IAdminLogic
    {
        private IAdminDao _adminDao;

        public AdminLogic(IAdminDao adminDao)
        {
            _adminDao = adminDao;
        }

        public Admin Register(Admin admin)
        {
            try
            {
                admin = _adminDao.Insert(admin);
                return admin;
            }
            catch (SqlException)
            {
                return admin;
            }
        }
    }
}
