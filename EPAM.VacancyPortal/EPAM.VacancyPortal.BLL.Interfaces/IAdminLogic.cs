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
        Admin Register(Admin admin);

        Admin Login(string login,string password);

        Admin SelectByLogin(string login);

        IEnumerable<Admin> GetAll();

        bool Verify(int id);

        bool DeleteById(int id);
    }
}
