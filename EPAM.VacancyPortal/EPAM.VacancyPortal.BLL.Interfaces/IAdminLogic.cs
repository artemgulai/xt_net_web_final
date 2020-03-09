using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IAdminLogic
    {
        /// <summary>
        /// Add new Admin to database.
        /// </summary>
        /// <param name="admin">Admin to be added.</param>
        /// <returns>Admin with ID != 0 if it has been added, otherwise Id = 0.</returns>
        Admin Register(Admin admin);

        /// <summary>
        /// Select Admin with specified login.
        /// </summary>
        /// <param name="login">Login of an Admin to be selected.</param>
        /// <returns>Admin if it exists, otherwise null.</returns>
        Admin SelectByLogin(string login);

        /// <summary>
        /// Select all Admins from database.
        /// </summary>
        /// <returns>IEnumerable<Admin></returns>        
        IEnumerable<Admin> SelectAll();

        /// <summary>
        /// Make Admin with specified Id non-candidate.
        /// </summary>
        /// <param name="id">Id of an Admin to be verified</param>
        /// <returns>True if Admin has been verified, otherwise false.</returns>
        bool Verify(int id);

        /// <summary>
        /// Delete Admin with specified Id from database
        /// </summary>
        /// <param name="id">Id of an Admin to deleted.</param>
        /// <returns>True if Admin has been deleted, otherwise false.</returns>        
        bool DeleteById(int id);
    }
}
