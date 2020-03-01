using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public class RequestResult
    {
        public string Result { get; set; }
        public string Message { get; set; }

        public RequestResult(string result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}