using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using Newtonsoft.Json;
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

        public static void DeleteById(HttpRequestBase req, HttpResponseBase res)
        {
            var result = _vacancyLogic.DeleteById(int.Parse(req["id"]));
            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Vacancy has been deleted")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Cannot delete vacancy")));
            }
        }

        public static void UpdateRequirementLevel(HttpRequestBase req, HttpResponseBase res)
        {
            var id = int.Parse(req["id"]);
            var level = int.Parse(req["level"]);
            var result = _vacancyLogic.UpdateRequirement(id,level);
            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Level has been changed.")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Cannot change level.")));
            }
        }

        public static RequestResult AddRequirement(Skill requirement, int vacancyId)
        {
            var result = _vacancyLogic.AddRequirement(requirement,vacancyId);
            if (result)
            {
                return new RequestResult("Success","Requirement has been added to the vacancy.");
            }
            else
            {
                return new RequestResult("Error","Cannot add requirement to vacancy.");
            }
        }

        public static void DeleteRequirement(HttpRequestBase req, HttpResponseBase res)
        {
            var result = _vacancyLogic.DeleteRequirement(int.Parse(req["id"]));
            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Requirement has been deleted.")));
                return;
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Cannot delete requirement.")));
                return;
            }
        }
    }
}