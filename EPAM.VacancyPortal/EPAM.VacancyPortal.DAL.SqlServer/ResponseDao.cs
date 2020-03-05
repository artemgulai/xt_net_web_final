using EPAM.VacancyPortal.DAL.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class ResponseDao : IResponseDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        private readonly ILog _logger = Configuration.Logger;

        public int InsertVacancyResponse(int vacancyId,int employeeId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertVacancyResponse",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("VacancyId",vacancyId);
                cmd.Parameters.AddWithValue("EmployeeId",employeeId);

                con.Open();
                try
                {
                    var id = (int)cmd.ExecuteScalar();
                    return id;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int DeleteVacancyResponse(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteVacancyResponse",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var rowsRemoved = cmd.ExecuteNonQuery();
                    return rowsRemoved;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int InsertEmployeeResponse(int vacancyId,int employeeId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertEmployeeResponse",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("VacancyId",vacancyId);
                cmd.Parameters.AddWithValue("EmployeeId",employeeId);

                con.Open();
                try
                {
                    var id = (int)cmd.ExecuteScalar();
                    return id;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        public int DeleteEmployeeResponse(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteEmployeeResponse",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                try
                {
                    var rowsRemoved = cmd.ExecuteNonQuery();
                    return rowsRemoved;
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
