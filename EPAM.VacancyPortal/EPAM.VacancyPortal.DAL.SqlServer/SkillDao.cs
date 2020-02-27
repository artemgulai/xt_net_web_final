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
    public class SkillDao : ISkillDao
    {
        private const System.Data.CommandType _storedProcedure = System.Data.CommandType.StoredProcedure;
        private readonly string _connectionString = Configuration.ConnectionString;

        public int DeleteById(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteSkillById",con);
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

        public IEnumerable<Skill> SelectAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_SelectAllSkills",con);
                cmd.CommandType = _storedProcedure;

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
                            Name = (string)result["Name"]
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

        public Skill Insert(Skill skill)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_InsertSkill",con);
                cmd.CommandType = _storedProcedure;

                cmd.Parameters.AddWithValue("Name",skill.Name);

                con.Open();
                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    skill.Id = id;
                    return skill;
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
