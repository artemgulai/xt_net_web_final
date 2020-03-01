using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class EmployerService
    {
        private static IEmployerLogic _employerLogic;
        
        static EmployerService()
        {
            _employerLogic = DependencyManager.Instance.EmployerLogic;
        }

        public static int Register(Employer employer)
        {
            return _employerLogic.Register(employer).Id;
        }

        public static bool CheckRole(string login,string roleName)
        {
            var employer = _employerLogic.SelectByLogin(login);
            return employer != null && employer.Role == roleName;
        }

        public static Employer SelectByLogin(string login)
        {
            return _employerLogic.SelectByLogin(login);
        }

        public static bool Update(Employer employer)
        {
            return _employerLogic.Update(employer);
        }

        public static Employer SelectById(int id)
        {
            return _employerLogic.SelectById(id);
        }

        public static bool Delete(int id)
        {
            return _employerLogic.Delete(id);
        }

        public static bool SignIn(string login, string password)
        {
            return _employerLogic.SignIn(login,password);
        }
    }
}