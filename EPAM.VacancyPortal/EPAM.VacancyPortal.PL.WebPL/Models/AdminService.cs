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
    }
}