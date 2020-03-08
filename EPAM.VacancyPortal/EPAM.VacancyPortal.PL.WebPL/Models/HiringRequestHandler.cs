using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class HiringRequestHandler
    {
        private static IHiringLogic _hiringLogic;
        static HiringRequestHandler()
        {
            _hiringLogic = DependencyManager.Instance.HiringLogic;
        }

        public static void AcceptEmployee(HttpRequestBase req, HttpResponseBase res)
        {
            var employeeId = int.Parse(req["employeeId"]);
            var vacancyId = int.Parse(req["vacancyId"]);
            var responseId = int.Parse(req["responseId"]);

            var result = _hiringLogic.AcceptEmployee(employeeId,vacancyId,responseId);

            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success", "Employee has been hired")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Employee cannot be hired")));
            }
        }

        public static void AcceptVacancy(HttpRequestBase req,HttpResponseBase res)
        {
            var employeeId = int.Parse(req["employeeId"]);
            var vacancyId = int.Parse(req["vacancyId"]);
            var responseId = int.Parse(req["responseId"]);

            var result = _hiringLogic.AcceptVacancy(employeeId,vacancyId,responseId);

            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Vacancy has been accepted")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Vacancy cannot be accepted")));
            }
        }

        public static void DeclineEmployee(HttpRequestBase req,HttpResponseBase res)
        {
            var responseId = int.Parse(req["responseId"]);

            var result = _hiringLogic.DeclineEmployee(responseId);

            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Response has been declined")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Response cannot be declined")));
            }
        }

        public static void DeclineVacancy(HttpRequestBase req,HttpResponseBase res)
        {
            var responseId = int.Parse(req["responseId"]);

            var result = _hiringLogic.DeclineVacancy(responseId);

            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Response has been declined")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Response cannot be declined")));
            }
        }

        public static bool CheckSkillsRequirementsVacancyResponse(IEnumerable<Skill> skills, IEnumerable<Skill> requirements)
        {
            return _hiringLogic.CheckSkillsRequirementsVacancyResponse(skills,requirements);
        }

        public static bool CheckSkillsRequirementsLevelsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements)
        {
            return _hiringLogic.CheckSkillsRequirementsLevelsVacancyResponse(skills,requirements);
        }
    }
}