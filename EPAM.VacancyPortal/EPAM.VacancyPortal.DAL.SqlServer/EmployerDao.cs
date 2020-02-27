using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class EmployerDao : IEmployerDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        private readonly ILog _logger = Configuration.Logger;

        public Employer Insert(Employer employer)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertEmployer",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Name",employer.Name);
                cmd.Parameters.AddWithValue("Logo",employer.Logo);
                cmd.Parameters.AddWithValue("Login",employer.Login);
                cmd.Parameters.AddWithValue("Password",employer.Password);
                cmd.Parameters.AddWithValue("City",employer.City);

                con.Open();
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    employer.Id = id;
                    employer.Vacancies = new List<Vacancy>();
                    return employer;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public Employer SelectById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectEmployerById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    Employer employer = null;
                    if (result.Read())
                    {
                        employer = new Employer
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Logo = (string)result["Logo"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            City = (string)result["City"],
                            Role = (string)result["Role"],
                            Vacancies = new List<Vacancy>()
                        };
                    }
                    return employer;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Employer> SelectAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllEmployers",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    var employers = new List<Employer>();
                    while (result.Read())
                    {
                        employers.Add(new Employer
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Logo = (string)result["Logo"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            City = (string)result["City"],
                            Role = (string)result["Role"],
                            Vacancies = new List<Vacancy>()
                        });
                    }
                    return employers;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int DeleteById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteEmployerById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public void DeleteAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteAllEmployers",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int Update(Employer employer)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateEmployer",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",employer.Id);
                cmd.Parameters.AddWithValue("Name",employer.Name);
                cmd.Parameters.AddWithValue("Logo",employer.Logo);
                cmd.Parameters.AddWithValue("Password",employer.Password);
                cmd.Parameters.AddWithValue("City",employer.City);

                con.Open();
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }
    }
}
