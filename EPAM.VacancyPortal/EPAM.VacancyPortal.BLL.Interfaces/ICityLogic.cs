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
        /// <summary>
        /// Invokes DAL's Insert method.
        /// </summary>
        /// <param name="city">City to be inserted into DB.</param>
        /// <returns>City with Id != 0 if it is inserted, otherwise Id = 0.</returns>
        City Insert(City city);

        /// <summary>
        /// Invokes DAL's SelectAll method.
        /// </summary>
        /// <returns>IEnumerable of Cities if a query is successfull, 
        /// otherwise empty List of Cities.</returns>
        IEnumerable<City> SelectAll();

        /// <summary>
        /// Invokes DAL's GetIdByName method.
        /// </summary>
        /// <param name="cityName">A Name of a City for which an Id is got.</param>
        /// <returns>Id if such City exists, otherwise 0.</returns>
        int SelectIdByName(string cityName);

        /// <summary>
        /// Invokes DAL's DeleteById method.
        /// </summary>
        /// <param name="id">Id of a City to be deleted.</param>
        /// <returns>Number of deleted rows.</returns>
        int DeleteById(int id);

        /// <summary>
        /// Invokes DAL's DeleteAll method.
        /// </summary>
        /// <returns>True if a query is successfull, otherwise false.</returns>
        bool DeleteAll();
    }
}
