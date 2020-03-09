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
            catch
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
            catch
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
            catch
            {
                return new List<City>();
            }
        }

        public int SelectIdByName(string cityName)
        {
            try
            {
                return _cityDao.SelectIdByName(cityName);
            }
            catch
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
            catch
            {
                return city;
            }
        }
    }
}
