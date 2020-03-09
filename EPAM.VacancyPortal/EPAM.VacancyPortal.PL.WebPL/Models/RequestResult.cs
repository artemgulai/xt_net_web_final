using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    /// <summary>
    /// This class is used when response is sent to *.cshtml pages.
    /// </summary>
    public class RequestResult
    {
        public string Result { get; private set; }
        public string Message { get; private set; }

        public RequestResult(string result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}