using log4net;
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
        private static ILog _logger;

        static Configuration()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MSSql"].ConnectionString;
            _logger = Logger;
        }

        internal static string ConnectionString => _connectionString;
        internal static ILog Logger => _logger;
    }
}
