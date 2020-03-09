using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface ICommonLogic
    {
        /// <summary>
        /// Check if login is not occupied.
        /// </summary>
        /// <param name="login">Login to be checked.</param>
        /// <returns>True is login is not occupied, otherwise false.</returns>
        bool CheckLogin(string login);
    }
}
