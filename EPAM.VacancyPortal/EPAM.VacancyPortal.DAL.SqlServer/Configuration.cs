using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    internal static class Configuration
    {
        private static string _connectionString;

        static Configuration()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;
        }

        internal static string ConnectionString => @"Server=DESKTOP-EGK7A33\SQLEXPRESS;Database=VacanciesDB;Trusted_Connection=True;";
    }
}
