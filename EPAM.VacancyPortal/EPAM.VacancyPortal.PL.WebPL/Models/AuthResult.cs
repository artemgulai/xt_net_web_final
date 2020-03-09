using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    /// <summary>
    /// This enum is used to indicate result of authentication attempt.
    /// </summary>
    public enum AuthResult
    {
        Candidate,
        Success,
        WrongPassword,
        LoginNotFound
    }
}