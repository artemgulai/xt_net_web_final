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

        public Admin Login(string login, string password)
        {
            try
            {
                var admin = _adminDao.SelectByLogin(login);
                if (admin == null || admin.Password != password)
                {
                    return null;
                }
                return admin;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public Admin SelectByLogin(string login)
        {
            try
            {
                return _adminDao.SelectByLogin(login);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            try
            {
                return _adminDao.SelectAll();
            }
            catch (SqlException)
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
            catch (SqlException)
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
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
