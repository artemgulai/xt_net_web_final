using EPAM.VacancyPortal.BLL.Interfaces;
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
    }
}