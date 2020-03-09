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
        /// Add City to database.
        /// </summary>
        /// <param name="city">City to be inserted to database.</param>
        /// <returns>City with Id != 0 if it has been added, otherwise Id = 0.</returns>
        City Insert(City city);

        /// <summary>
        /// Select all Cities from database.
        /// </summary>
        /// <returns>IEnumerable of Cities if a query is successfull, 
        /// otherwise empty List of Cities.</returns>
        IEnumerable<City> SelectAll();

        /// <summary>
        /// Select City's Id by its name.
        /// </summary>
        /// <param name="cityName">A Name of a City for which an Id is got.</param>
        /// <returns>Id if such City exists, otherwise 0.</returns>
        int SelectIdByName(string cityName);

        /// <summary>
        /// Delete City with speicified Id from database.
        /// </summary>
        /// <param name="id">Id of a City to be deleted.</param>
        /// <returns>Number of deleted rows.</returns>
        int DeleteById(int id);

        /// <summary>
        /// Delete all Cities from database.
        /// </summary>
        /// <returns>True if a query is successfull, otherwise false.</returns>
        bool DeleteAll();
    }
}
