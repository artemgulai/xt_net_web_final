using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    internal static class Configuration
    {
        internal static string ConnectionString => @"Server=DESKTOP-EGK7A33\SQLEXPRESS;Database=VacanciesDB;Trusted_Connection=True;";
    }
}
