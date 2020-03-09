using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IEmployerLogic
    {
        /// <summary>
        /// Add new Employer to database.
        /// </summary>
        /// <param name="employer">Employer to be added to database.</param>
        /// <returns>Employer with ID != 0 if it has been added, otherwise Id = 0.</returns>
        Employer Register(Employer employer);

        /// <summary>
        /// Select Employer with specified login.
        /// </summary>
        /// <param name="login">Login of an Employer to be selected.</param>
        /// <returns>Employee if it exists, otherwise null.</returns>
        Employer SelectByLogin(string login);

        /// <summary>
        /// Select Employer with specified Id.
        /// </summary>
        /// <param name="id">Id of an Employer to be selected.</param>
        /// <returns>Employer if it exists, otherwise null.</returns>
        Employer SelectById(int id);

        /// <summary>
        /// Select all Employers from database.
        /// </summary>
        /// <returns>IEnumerable<Employer></returns> 
        IEnumerable<Employer> SelectAll();

        /// <summary>
        /// Update Employer in database.
        /// </summary>
        /// <param name="employer">Employer with updated properties.</param>
        /// <returns>True if it has been updated.</returns>
        bool Update(Employer employer);

        /// <summary>
        /// Delete Employer with specified Id from database
        /// </summary>
        /// <param name="id">Id of an Employer.</param>
        /// <returns>True if Employer has been deleted, otherwise false.</returns> 
        bool Delete(int id);
    }
}
