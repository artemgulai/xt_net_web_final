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
    public class VacancyLogic : IVacancyLogic
    {
        private IVacancyDao _vacancyDao;
        public VacancyLogic(IVacancyDao vacancyDao)
        {
            _vacancyDao = vacancyDao;
        }

        public Vacancy Insert(Vacancy vacancy)
        {
            try
            {
                return _vacancyDao.Insert(vacancy);
            }
            catch (SqlException)
            {
                return vacancy;
            }
        }

        public IEnumerable<Vacancy> SelectByEmployer(Employer employer)
        {
            try
            {
                return _vacancyDao.SelectAllByEmployer(employer);
            }
            catch (SqlException)
            {
                return new Vacancy[] { };
            }
        }

        public Vacancy SelectById(int id)
        {
            try
            {
                return _vacancyDao.SelectById(id);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool Update(Vacancy vacancy)
        {
            try
            {
                return _vacancyDao.Update(vacancy) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
