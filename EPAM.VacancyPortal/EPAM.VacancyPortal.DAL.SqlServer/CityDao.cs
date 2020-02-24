using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using static EPAM.VacancyPortal.Logger.Logger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.SqlServer
{
    public class CityDao : ICityDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;
        public void DeleteAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteAllCities",con);
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

        public int DeleteById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteCityById", con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                con.Open();
                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();
                try
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public IEnumerable<City> GetAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetAllCities", con);
                cmd.CommandType = _storedProcedure;

                con.Open();
                try
                {
                    var result = cmd.ExecuteReader();
                    List<City> cities = new List<City>();
                    while(result.Read())
                    {
                        cities.Add(new City
                        {
                            Id = (int)result["Id"],
                            Name = (string)result["Name"]
                        });
                    }
                    return cities;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public int GetIdByName(string cityName)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetCityId",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Name",cityName);

                con.Open();
                try
                {
                    int? id = cmd.ExecuteScalar() as int?;
                    return id == null ? 0 : id.Value;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }
        }

        public City Insert(City city)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertCity",con);
                cmd.CommandType = _storedProcedure;
                
                cmd.Parameters.AddWithValue("Name",city.Name);

                con.Open();
                
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    city.Id = id;
                    return city;
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
