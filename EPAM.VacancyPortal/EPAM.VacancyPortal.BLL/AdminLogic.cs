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
            catch
            {
                return admin;
            }
        }

        public Admin SelectByLogin(string login)
        {
            try
            {
                return _adminDao.SelectByLogin(login);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Admin> SelectAll()
        {
            try
            {
                return _adminDao.SelectAll();
            }
            catch
            {
                return new List<Admin>();
            }
        }

        public bool Verify(int id)
        {
            try
            {
                var admin = _adminDao.SelectById(id);
                admin.IsCandidate = false;
                _adminDao.Update(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteById(int id)
        {
            try
            {
                return _adminDao.DeleteById(id) != 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
