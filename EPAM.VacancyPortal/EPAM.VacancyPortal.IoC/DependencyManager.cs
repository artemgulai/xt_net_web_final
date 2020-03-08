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

        private IEmployerDao _employerDao;
        private IEmployerLogic _employerLogic;

        private IEmployeeDao _employeeDao;
        private IEmployeeLogic _employeeLogic;

        private ICityDao _cityDao;
        private ICityLogic _cityLogic;

        private ISkillDao _skillDao;
        private ISkillLogic _skillLogic;

        private IVacancyDao _vacancyDao;
        private IVacancyLogic _vacancyLogic;

        private IHiringLogic _hiringLogic;

        private IResponseDao _responseDao;

        private ICommonLogic _commonLogic;


        private DependencyManager()
        {
            _adminDao = new AdminDao();
            _adminLogic = new AdminLogic(_adminDao);

            _cityDao = new CityDao();
            _cityLogic = new CityLogic(_cityDao);

            _skillDao = new SkillDao();
            _skillLogic = new SkillLogic(_skillDao);

            _responseDao = new ResponseDao();

            _employeeDao = new EmployeeDao();
            _employeeLogic = new EmployeeLogic(_employeeDao, _responseDao, _cityLogic, _skillLogic);

            _vacancyDao = new VacancyDao();
            _vacancyLogic = new VacancyLogic(_vacancyDao, _skillLogic,_responseDao);

            _employerDao = new EmployerDao();
            _employerLogic = new EmployerLogic(_employerDao,_cityLogic, _vacancyLogic);

            _hiringLogic = new HiringLogic(_vacancyLogic,_employeeLogic);

            _commonLogic = new CommonLogic(_adminDao,_employerDao,_employeeDao);
        }

        public static DependencyManager Instance => _instance ?? (_instance = new DependencyManager());
        public IAdminLogic AdminLogic => _adminLogic;
        public IEmployerLogic EmployerLogic => _employerLogic;
        public IEmployeeLogic EmployeeLogic => _employeeLogic;
        public ICityLogic CityLogic => _cityLogic;
        public ICommonLogic CommonLogic => _commonLogic;
        public IVacancyLogic VacancyLogic => _vacancyLogic;
        public IHiringLogic HiringLogic => _hiringLogic;
    }
}
