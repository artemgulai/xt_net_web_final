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
        /// Invokes DAL's Insert method.
        /// </summary>
        /// <param name="skill">Skill to be inserted into DB.</param>
        /// <returns>Skill with Id != 0 if it is inserted, otherwise Id = 0.</returns>
        Skill Insert(Skill skill);

        /// <summary>
        /// Invokes DAL's SelectAll method.
        /// </summary>
        /// <returns>IEnumerable of Skills if a query is successfull, 
        /// otherwise empty List of Skills.</returns>
        IEnumerable<Skill> SelectAll();

        /// <summary>
        /// Invokes DAL's DeleteById method.
        /// </summary>
        /// <param name="id">Id of a Skill to be deleted.</param>
        /// <returns>Number of deleted rows.</returns>
        int DeleteById(int id);
    }
}
