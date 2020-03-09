using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IVacancyLogic
    {
        /// <summary>
        /// Add new Vacancy to database.
        /// </summary>
        /// <param name="vacancy">Vacancy to be added to database.</param>
        /// <returns>Vacancy with ID != 0 if it has been added, otherwise Id = 0.</returns>
        Vacancy Insert(Vacancy vacancy);

        /// <summary>
        /// Select Vacancies by Employer.
        /// </summary>
        /// <param name="employer">Employer whose Vacancies are selected.</param>
        /// <returns>IEnumerable of Vacancies if they exist, 
        /// otherwise empty List of Vacancies.</returns>
        IEnumerable<Vacancy> SelectByEmployer(Employer employer);

        /// <summary>
        /// Select Vacancy with specified Id.
        /// </summary>
        /// <param name="id">Id of a Vacancy to be selected.</param>
        /// <returns>Vacancy if it exists, otherwise null.</returns>
        Vacancy SelectById(int id);

        /// <summary>
        /// Update Vacancy in database.
        /// </summary>
        /// <param name="employee">Vacancy with updated properties.</param>
        /// <returns>True if it has been updated.</returns>
        bool Update(Vacancy vacancy);

        /// <summary>
        /// Activate Vacancy.
        /// </summary>
        /// <param name="id">Id of a Vacancy.</param>
        /// <returns>True if it has been activated, otherwise false.</returns>
        bool Activate(int id);

        /// <summary>
        /// Dectivate Vacancy.
        /// </summary>
        /// <param name="id">Id of a Vacancy.</param>
        /// <returns>True if it has been deactivated, otherwise false.</returns>
        bool Deactivate(int id);

        /// <summary>
        /// Delete Vacancy with specified Id from database
        /// </summary>
        /// <param name="id">Id of a Vacancy.</param>
        /// <returns>True if it has been deleted, otherwise false.</returns>
        bool DeleteById(int id);

        /// <summary>
        /// Add Requirement to Vacancy.
        /// </summary>
        /// <param name="requirement">Requirement to be added.</param>
        /// <param name="vacancyId">Id of a Vacancy to be added Skill.</param>
        /// <returns>True if it has been added, otherwise false.</returns>
        bool AddRequirement(Skill requirement,int vacancyId);

        /// <summary>
        /// Update Requirement.
        /// </summary>
        /// <param name="id">Id of a Requirement to be updated.</param>
        /// <param name="level">New Requirement's level.</param>
        /// <returns>True if it has been updated, otherwise false.</returns>
        bool UpdateRequirement(int id,int level);

        /// <summary>
        /// Delete Requirement with specified Id.
        /// </summary>
        /// <param name="id">Id of a Requirement.</param>
        /// <returns>True if it has been deleted, otherwise false</returns>
        bool DeleteRequirement(int id);

        /// <summary>
        /// Add new Response to Employee's profile by Vacancy.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <returns>True if it has been added, otherwise false.</returns>
        bool InsertEmployeeResponse(int employeeId,int vacancyId);

        /// <summary>
        /// Delete Response to Employee's profile by Vacancy.
        /// </summary>
        /// <param name="id">Id of a Response.</param>
        /// <returns>True if it has been deleted.</returns>
        bool DeleteEmployeeResponse(int id);

        /// <summary>
        /// Delete Responses to Vacancy by Employee 
        /// and to Employee by Vacancy if Employee has accepted response.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <returns>True if deletion is successfull, otherwise false.</returns>
        bool DeleteHiredEmployeeResponses(int employeeId, int vacancyId);

        /// <summary>
        /// Select all Responses to Employees' profiles by Vacancies.
        /// </summary>
        /// <returns>IEnumerable<Response></returns>
        IEnumerable<Response> SelectAllEmployeeResponses();
    }
}
