using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface ISkillLogic
    {
        /// <summary>
        /// Add new Skill to database.
        /// </summary>
        /// <param name="skill">Skill to be added.</param>
        /// <returns>Skill with Id != 0 if it has been added, otherwise Id = 0.</returns>
        Skill Insert(Skill skill);

        /// <summary>
        /// Select all Skills from database.
        /// </summary>
        /// <returns>IEnumerable of Skills if a query is successfull, 
        /// otherwise empty List of Skills.</returns>
        IEnumerable<Skill> SelectAll();

        /// <summary>
        /// Delete Skill with specified Id.
        /// </summary>
        /// <param name="id">Id of a Skill to be deleted.</param>
        /// <returns>Number of deleted rows.</returns>
        int DeleteById(int id);
    }
}
