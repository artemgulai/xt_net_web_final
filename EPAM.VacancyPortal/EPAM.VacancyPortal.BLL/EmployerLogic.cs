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
    public class EmployerLogic : IEmployerLogic
    {
        private IEmployerDao _employerDao;
        private ICityLogic _cityLogic;
        private IVacancyLogic _vacancyLogic;

        public EmployerLogic(IEmployerDao employerDao, ICityLogic cityLogic, IVacancyLogic vacancyLogic)
        {
            _employerDao = employerDao;
            _cityLogic = cityLogic;
            _vacancyLogic = vacancyLogic;
        }

        public Employer Register(Employer employer)
        {
            int id = _cityLogic.SelectIdByName(employer.City);
            if (id == 0)
            {
                _cityLogic.Insert(new City { Name = employer.City });
            }

            try
            {
                return _employerDao.Insert(employer);
            }
            catch (SqlException)
            {
                return employer;
            }
        }

        public Employer SelectByLogin(string login)
        {
            try
            {
                var employer = _employerDao.SelectByLogin(login);
                if (employer != null)
                {
                    employer.Vacancies = _vacancyLogic.SelectByEmployer(employer).ToList();
                }
                return employer;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool Update(Employer employer)
        {
            int id = _cityLogic.SelectIdByName(employer.City);
            if (id == 0)
            {
                _cityLogic.Insert(new City { Name = employer.City });
            }

            try
            {
                return _employerDao.Update(employer) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public Employer SelectById(int id)
        {
            try
            {
                var employer = _employerDao.SelectById(id);
                if (employer != null)
                {
                    employer.Vacancies = _vacancyLogic.SelectByEmployer(employer).ToList();
                }
                return employer;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public IEnumerable<Employer> SelectAll()
        {
            try
            {
                var employers = _employerDao.SelectAll();
                foreach(var employer in employers)
                {
                    employer.Vacancies = _vacancyLogic.SelectByEmployer(employer).ToList();
                }
                return employers;
            }
            catch (SqlException)
            {
                return new List<Employer>();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _employerDao.DeleteById(id) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool SignIn(string login,string password)
        {
            try
            {
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
