﻿using EPAM.VacancyPortal.DAL.Interfaces;
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
    public class ResponseDao : IResponseDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        private readonly ILog _logger = Configuration.Logger;

        // response to vacancy by employee
        public int InsertVacancyResponse(int employeeId,int vacancyId)
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

        // response to vacancy by employee
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

        // response to vacancy by employee
        public IEnumerable<Response> SelectAllVacancyResponses()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllVacancyResponses",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    List<Response> responses = new List<Response>();
                    while (result.Read())
                    {
                        responses.Add(new Response
                        {
                            Id = (int)result["Id"],
                            EmployeeId = (int)result["EmployeeId"],
                            VacancyId = (int)result["VacancyId"],
                            EmployerId = (int)result["EmployerId"]
                        });
                    }
                    return responses;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                }
            }
        }

        // response to employee by employer's vacancy
        public int InsertEmployeeResponse(int employeeId,int vacancyId)
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

        // response to employee by employer's vacancy
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

        // response to employee by employer's vacancy
        public IEnumerable<Response> SelectAllEmployeeResponses()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllEmployeeResponses",con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    List<Response> responses = new List<Response>();
                    while(result.Read())
                    {
                        responses.Add(new Response
                        {
                            Id = (int)result["Id"],
                            EmployeeId = (int)result["EmployeeId"],
                            VacancyId = (int)result["VacancyId"],
                            EmployerId = (int)result["EmployerId"]
                        });
                    }
                    return responses;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw e;
                } 
            }
        }

        public int DeleteHiredVacancyResponses(int employeeId,int vacancyId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteHiredVacancyResponses",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employeeId);
                cmd.Parameters.AddWithValue("VacancyId",vacancyId);

                con.Open();
                try
                {
                    var result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw;
                }
            }
        }

        public int DeleteHiredEmployeeResponses(int employeeId,int vacancyId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteHiredEmployeeResponses",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("EmployeeId",employeeId);
                cmd.Parameters.AddWithValue("VacancyId",vacancyId);

                con.Open();
                try
                {
                    var result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (SqlException e)
                {
                    _logger.Error(e.Message);
                    throw;
                }
            }
        }
    }
}
