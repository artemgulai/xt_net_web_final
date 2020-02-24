using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL
{
    public class CityLogic : ICityLogic
    {
        private ICityDao _cityDao;

        public CityLogic(ICityDao cityDao)
        {
            _cityDao = cityDao;
        }

        public bool DeleteAll()
        {
            try
            {
                _cityDao.DeleteAll();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                return _cityDao.DeleteById(id);
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        public IEnumerable<City> SelectAll()
        {
            try
            {
                return _cityDao.SelectAll();
            }
            catch (SqlException)
            {
                return new List<City>();
            }
        }

        public int GetIdByName(string cityName)
        {
            try
            {
                return _cityDao.GetIdByName(cityName);
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        public City Insert(City city)
        {
            try
            {
                return _cityDao.Insert(city);
            }
            catch (SqlException)
            {
                return city;
            }
        }
    }
}
