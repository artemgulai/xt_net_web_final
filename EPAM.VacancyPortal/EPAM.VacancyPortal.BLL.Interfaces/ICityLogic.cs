using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface ICityLogic
    {
        City Insert(City city);
        IEnumerable<City> GetAll();
        int GetIdByName(string cityName);
        int DeleteById(int id);
        bool DeleteAll();
    }
}
