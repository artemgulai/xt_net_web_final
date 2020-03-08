using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class AdminDao : IAdminDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        private readonly ILog _logger = Configuration.Logger;

        public int DeleteById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteAdminById", con);
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

        public Admin Insert(Admin admin)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertAdmin",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Login",admin.Login);
                cmd.Parameters.AddWithValue("Password",admin.Password);
                cmd.Parameters.AddWithValue("Role","ADMIN");

                con.Open();
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    admin.Id = id;
                    admin.IsCandidate = true;
                    return admin;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<Admin> SelectAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllAdmins",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    List<Admin> admins = new List<Admin>();
                    while (result.Read())
                    {
                        admins.Add(new Admin
                        {
                            Id = (int)result["Id"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            Role = (string)result["Role"],
                            IsCandidate = (bool)result["Candidate"]
                        });
                    }
                    return admins;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public Admin SelectById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAdminById", con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    Admin admin = null;
                    if (result.Read())
                    {
                        admin = new Admin 
                        {
                            Id = (int)result["Id"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            Role = (string)result["Role"],
                            IsCandidate = (bool)result["Candidate"]
                        };
                    }
                    return admin;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public Admin SelectByLogin(string login)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAdminByLogin",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Login",login);

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    Admin admin = null;
                    if (result.Read())
                    {
                        admin = new Admin
                        {
                            Id = (int)result["Id"],
                            Login = (string)result["Login"],
                            Password = (string)result["Password"],
                            Role = (string)result["Role"],
                            IsCandidate = (bool)result["Candidate"]
                        };
                    }
                    return admin;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int Update(Admin admin)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_UpdateAdminById",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",admin.Id);
                cmd.Parameters.AddWithValue("Candidate",admin.IsCandidate);

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
