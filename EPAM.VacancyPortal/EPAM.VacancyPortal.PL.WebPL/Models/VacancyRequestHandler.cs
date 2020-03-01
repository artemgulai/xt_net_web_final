using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class VacancyRequestHandler
    {
        private static IVacancyLogic _vacancyLogic;

        static VacancyRequestHandler()
        {
            _vacancyLogic = DependencyManager.Instance.VacancyLogic;
        }

        public static RequestResult InsertVacancy(Vacancy vacancy)
        {
            vacancy = _vacancyLogic.Insert(vacancy);
            if (vacancy.Id != 0)
            {
                return new RequestResult("Success","Vacancy has been added.");
            }
            else
            {
                return new RequestResult("Error","Cannot add vacancy.");
            }
        }

        public static IEnumerable<Vacancy> SelectByEmployer(Employer employer)
        {
            return _vacancyLogic.SelectByEmployer(employer);
        }

        public static Vacancy SelectById(int id)
        {
            return _vacancyLogic.SelectById(id);
        }

        public static RequestResult Update(Vacancy vacancy)
        {
            var result = _vacancyLogic.Update(vacancy);
            if (result)
            {
                return new RequestResult("Success","Vacancy has been changed.");
            }
            else
            {
                return new RequestResult("Error","Cannot change vacancy.");
            }
        }
    }
}