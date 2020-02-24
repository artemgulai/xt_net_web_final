using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface ICityDao
    {
        City Insert(City city);
        IEnumerable<City> SelectAll();
        int GetIdByName(string cityName);
        int DeleteById(int id);
        void DeleteAll();
    }
}
