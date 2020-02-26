using EPAM.VacancyPortal.BLL;
using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.DAL.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.IoC
{
    public class DependencyManager
    {
        private static DependencyManager _instance;

        private IAdminDao _adminDao;
        private IAdminLogic _adminLogic;

        private DependencyManager()
        {
            _adminDao = new AdminDao();
            _adminLogic = new AdminLogic(_adminDao);
        }

        public static DependencyManager Instance => _instance ?? (_instance = new DependencyManager());
        public IAdminDao AdminDao => _adminDao;
        public IAdminLogic AdminLogic => _adminLogic;
    }
}
