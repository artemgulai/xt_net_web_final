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
        private readonly string _connectionString = Configuration.ConnectionString;
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string cityName)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_GetCityId",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                    return 0;
                }
            }
        }

        public City Insert(City city)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertCity",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("Name",city.Name);

                con.Open();
                
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    city.Id = id;
                }
                catch (SqlException e)
                {
                    Log.Error(e.Message);
                }

                return city;
            }
        }
    }
}
