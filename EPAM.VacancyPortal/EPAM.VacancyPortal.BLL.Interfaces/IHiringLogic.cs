using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IHiringLogic
    {
        /// <summary>
        /// Accept response to Employee's profile by Vacancy.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <param name="responseId">Id of a Response.</param>
        /// <returns>True if Response has been accepted successfully.</returns>
        bool AcceptEmployee(int employeeId,int vacancyId,int responseId);

        /// <summary>
        /// Delete Response to Employee's profile.
        /// </summary>
        /// <param name="responseId">Id of a response.</param>
        /// <returns>True if Response has been deleted, otherwise false.</returns>
        bool DeclineEmployee(int responseId);

        /// <summary>
        /// Accept response to Vacancy by Employee.
        /// </summary>
        /// <param name="employeeId">Id of an Employee.</param>
        /// <param name="vacancyId">Id of a Vacancy.</param>
        /// <param name="responseId">Id of a Response.</param>
        /// <returns>True if Response has been accepted successfully.</returns>
        bool AcceptVacancy(int employeeId,int vacancyId,int responseId);

        /// <summary>
        /// Delete Response to Vacancy.
        /// </summary>
        /// <param name="responseId">Id of a response.</param>
        /// <returns>True if Response has been deleted, otherwise false.</returns>
        bool DeclineVacancy(int responseId);

        /// <summary>
        /// Check if Employee has all skills matching Vacancy's requirements.
        /// </summary>
        /// <param name="skills">Employee's skills</param>
        /// <param name="requirements">Vacancy's requirements</param>
        /// <returns>True if Employee has all skills, otherwise false.</returns>
        bool CheckSkillsRequirementsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements);

        /// <summary>
        /// Check if Employee has all skills matching Vacancy's requirements and their levels also match.
        /// </summary>
        /// <param name="skills">Employee's skills</param>
        /// <param name="requirements">Vacancy's requirements</param>
        /// <returns>True if Employee has all skills and levels match, otherwise false.</returns>
        bool CheckSkillsRequirementsLevelsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements);
    }
}
