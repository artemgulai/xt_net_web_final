using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class AdminService
    {
        private static IAdminLogic _adminLogic;

        static AdminService()
        {
            _adminLogic = DependencyManager.Instance.AdminLogic;
        }

        public static int Register(Admin admin)
        {
            return _adminLogic.Register(admin).Id;
        }

        public static Admin Login(string login, string password)
        {
            return _adminLogic.Login(login,password);
        }

        public static bool CheckRole(string login, string roleName)
        {
            var admin = _adminLogic.SelectByLogin(login);
            return admin != null && admin.Role == roleName;
        }

        public static Admin SelectByLogin(string login)
        {
            return _adminLogic.SelectByLogin(login);
        }

        public static IEnumerable<Admin> GetAll()
        {
            return _adminLogic.GetAll();
        }

        public static bool Verify(int id)
        {
            return _adminLogic.Verify(id);
        }

        public static bool DeleteById(int id)
        {
            return _adminLogic.DeleteById(id);
        }
    }
}