using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IEmployeeLogic
    {
        /// <summary>
        /// Add new Employee to database.
        /// </summary>
        /// <param name="employee">Employee to be added to database.</param>
        /// <returns>Employee with ID != 0 if it has been added, otherwise Id = 0.</returns>
        Employee Register(Employee employee);

        /// <summary>
        /// Select Employee with specified login.
        /// </summary>
        /// <param name="login">Login of an Employee to be selected.</param>
        /// <returns>Employee if it exists, otherwise null.</returns>
        Employee SelectByLogin(string login);

        /// <summary>
        /// Select Employee with specified Id.
        /// </summary>
        /// <param name="id">Id of an Employee to be selected.</param>
        /// <returns>Employee if it exists, otherwise null.</returns>
        Employee SelectById(int id);

        /// <summary>
        /// Select all Employees from database.
        /// </summary>
        /// <returns>IEnumerable<Employee></returns> 
        IEnumerable<Employee> SelectAll();

        /// <summary>
        /// Update Employee in database.
        /// </summary>
        /// <param name="employee">Employee with updated properties.</param>
        /// <returns>True if it has been updated.</returns>
        bool Update(Employee employee);

        /// <summary>
        /// Delete Employee with specified Id from database
        /// </summary>
        /// <param name="id">Id of an Employee.</param>
        /// <returns>True if it has been deleted, otherwise false.</returns> 
        bool DeleteById(int id);

        /// <summary>
        /// Activate Employee's profile.
        /// </summary>
        /// <param name="id">Id of an Employee.</param>
        /// <returns>True if it has been activated, otherwise false.</returns>
        bool Activate(int id);

        /// <summary>
        /// Dectivate Employee's profile.
        /// </summary>
        /// <param name="id">Id of an Employee.</param>
        /// <returns>True if it has been deactivated, otherwise false.</returns>
        bool Deactivate(int id);

        /// <summary>
        /// Add Skill to Employee's profile.
        /// </summary>
        /// <param name="skill">Skill to be added.</param>
        /// <param name="employeeId">Id of an Employee to be added Skill.</param>
        /// <returns>True if it has been added, otherwise false.</returns>
        bool AddSkill(Skill skill,int employeeId);

        /// <summary>
        /// Update Skill.
        /// </summary>
        /// <param name="id">Id of a Skill to be updated.</param>
        /// <param name="level">New Skill's level.</param>
        /// <returns>True if it has been updated, otherwise false.</returns>
        bool UpdateSkill(int id,int level);

        /// <summary>
        /// Delete Skill with specified Id.
        /// </summary>
        /// <param name="id">Id of a Skill.</param>
        /// <returns>True if it has been deleted, otherwise false</returns>
        bool DeleteSkill(int id);

        /// <summary>
        /// Add new Response to Vacancy by Employee.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <returns>True if it has been added, otherwise false.</returns>
        bool InsertVacancyResponse(int employeeId,int vacancyId);

        /// <summary>
        /// Delete Response to Vacancy by Employee.
        /// </summary>
        /// <param name="id">Id of a Response.</param>
        /// <returns>True if it has been deleted.</returns>
        bool DeleteVacancyResponse(int id);

        /// <summary>
        /// Delete Responses to Vacancy by Employee 
        /// and to Employee by Vacancy if Employee's response is accepted.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <returns>True if deletion is successfull, otherwise false.</returns>
        bool DeleteHiredVacancyResponses(int employeeId,int vacancyId);

        /// <summary>
        /// Select all Responses to Vacancies by Employees.
        /// </summary>
        /// <returns>IEnumerable<Response></returns>
        IEnumerable<Response> SelectAllVacancyResponses();
    }
}
