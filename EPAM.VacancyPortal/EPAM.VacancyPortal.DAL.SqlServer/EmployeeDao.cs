using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EPAM.VacancyPortal.Logger.Logger;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class EmployeeDao : IEmployeeDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;

        public Employee Insert(Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertEmployee",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("FirstName",employee.FirstName);
                cmd.Parameters.AddWithValue("LastName",employee.LastName);
                cmd.Parameters.AddWithValue("Relocation",employee.Relocation);
                cmd.Parameters.AddWithValue("Experience",employee.Experience);
                cmd.Parameters.AddWithValue("Login",employee.Login);
                cmd.Parameters.AddWithValue("Password",employee.Password);
                cmd.Parameters.AddWithValue("City",employee.City);

                con.Open();
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    employee.Id = id;
                    employee.Role = "EMPLOYEE";
                    return employee;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Employee> SelectAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetAllEmployees",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    var employees = new List<Employee>();
                    while (result.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = (int)result["Id"],
                            FirstName = (string)result["FirstName"],
                            LastName = (string)result["LastName"],
                            Relocation = (bool)result["Relocation"],
                            Experience = (int)result["Experience"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            City = (string)result["City"],
                            Role = (string)result["Role"],
                            Skills = new List<Skill>()
                        });
                    }
                    return employees;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public Employee SelectById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetEmployeeById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    Employee employee = null;
                    if (result.Read())
                    {
                        employee = new Employee
                        {
                            Id = (int)result["Id"],
                            FirstName = (string)result["FirstName"],
                            LastName = (string)result["LastName"],
                            Relocation = (bool)result["Relocation"],
                            Experience = (int)result["Experience"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            City = (string)result["City"],
                            Role = (string)result["Role"],
                            Skills = new List<Skill>()
                        };
                    }
                    return employee;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public int DeleteById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteEmployeeById",con);
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
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public void DeleteAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteAllEmployees",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public int Update(Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateEmployee",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",employee.Id);
                cmd.Parameters.AddWithValue("FirstName",employee.FirstName);
                cmd.Parameters.AddWithValue("LastName",employee.LastName);
                cmd.Parameters.AddWithValue("Relocation",employee.Relocation);
                cmd.Parameters.AddWithValue("Experience",employee.Experience);
                cmd.Parameters.AddWithValue("Password",employee.Password);
                cmd.Parameters.AddWithValue("City",employee.City);

                con.Open();
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (SqlException e)
                {
                    Log.Error(e);
                    throw e;
                }

            }
        }

        public int AddSkill(Skill skill, Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_AddSkillEmployee");
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employee.Id);
                cmd.Parameters.AddWithValue("SkillId",skill.Id);
                cmd.Parameters.AddWithValue("Level",skill.Level);

                con.Open();
                try
                {
                    int rowsAdded = cmd.ExecuteNonQuery();
                    return rowsAdded;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public int RemoveSkill(Skill skill, Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_RemoveSkillEmployee");
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employee.Id);
                cmd.Parameters.AddWithValue("SkillId",skill.Id);

                con.Open();
                try
                {
                    int rowsAdded = cmd.ExecuteNonQuery();
                    return rowsAdded;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public int UpdateSkill(Skill skill,Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateSkillEmployee");
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employee.Id);
                cmd.Parameters.AddWithValue("SkillId",skill.Id);
                cmd.Parameters.AddWithValue("Level",skill.Level);

                con.Open();
                try
                {
                    int rowsAdded = cmd.ExecuteNonQuery();
                    return rowsAdded;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Skill> SelectSkillsByEmployee(Employee employee)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetSkillsByEmployee", con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employee.Id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    List<Skill> skills = new List<Skill>();
                    while (result.Read())
                    {
                        skills.Add(new Skill
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"],
                            Level = (int)result["Level"]
                        });
                    }
                    return skills;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }

            }
        }
    }
}
