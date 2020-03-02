using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using static EPAM.VacancyPortal.Logger.Logger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class VacancyDao : IVacancyDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        private readonly ILog _logger = Configuration.Logger;

        public Vacancy Insert(Vacancy vacancy)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertVacancy", con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Name",vacancy.Name);
                cmd.Parameters.AddWithValue("Description",vacancy.Description);
                cmd.Parameters.AddWithValue("Salary",vacancy.Salary);
                cmd.Parameters.AddWithValue("Remote",vacancy.Remote);
                cmd.Parameters.AddWithValue("EmployerId",vacancy.Employer.Id);

                con.Open();
                try
                {
                    var id = (int)cmd.ExecuteScalar();
                    vacancy.Id = id;
                    vacancy.Requirements = new List<Skill>();
                    return vacancy;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public Vacancy SelectById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectVacancyById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    Vacancy vacancy = null;
                    if (result.Read())
                    {
                        vacancy = new Vacancy
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Description = (string)result["Description"],
                            Remote = (bool)result["Remote"],
                            Salary = (int)result["Salary"],
                            Requirements = new List<Skill>()
                        };
                    }
                    return vacancy;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Vacancy> SelectAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllVacancies", con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    var vacancies = new List<Vacancy>();
                    while (result.Read())
                    {
                        vacancies.Add(new Vacancy 
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Description = (string)result["Description"],
                            Salary = (int)result["Salary"],
                            Remote = (bool)result["Remote"],
                            Requirements = new List<Skill>()
                        });
                    }
                    return vacancies;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Vacancy> SelectAllByEmployer(Employer employer)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllVacanciesByEmployer",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployerId",employer.Id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    var vacancies = new List<Vacancy>();
                    while (result.Read())
                    {
                        vacancies.Add(new Vacancy
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Description = (string)result["Description"],
                            Salary = (int)result["Salary"],
                            Remote = (bool)result["Remote"],
                            Employer = employer,
                            Requirements = new List<Skill>()
                        });
                    }
                    return vacancies;
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
                var cmd = new SqlCommand("sp_DeleteVacancyById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

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

        public void DeleteAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteAllVacancies",con);
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

        public int Update(Vacancy vacancy)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateVacancy",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",vacancy.Id);
                cmd.Parameters.AddWithValue("Name",vacancy.Name);
                cmd.Parameters.AddWithValue("Description",vacancy.Description);
                cmd.Parameters.AddWithValue("Salary",vacancy.Salary);
                cmd.Parameters.AddWithValue("Remote",vacancy.Remote);

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

        public int InsertRequirement(Skill skill,int vacancyId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertRequirementVacancy",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("VacancyId",vacancyId);
                cmd.Parameters.AddWithValue("SkillId",skill.Id);
                cmd.Parameters.AddWithValue("Level",skill.Level);

                con.Open();
                try
                {
                    var rowsAdded = cmd.ExecuteNonQuery();
                    return rowsAdded;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int DeleteRequirement(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteRequirementVacancy",con);
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

        public IEnumerable<Skill> SelectRequirementsByVacancy(Vacancy vacancy)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectRequirementsByVacancy",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("VacancyId",vacancy.Id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    var requirements = new List<Skill>();
                    while(result.Read())
                    {
                        requirements.Add(new Skill
                        { 
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Level = (int)result["Level"]
                        });
                    }
                    return requirements;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public Skill SelectRequirementById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectRequirementById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    if (result.Read())
                    {
                        return new Skill
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Level = (int)result["Level"]
                        };
                    }
                    return null;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int UpdateRequirement(Skill skill)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateRequirement",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",skill.Id);
                cmd.Parameters.AddWithValue("Level",skill.Level);

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
    }
}
