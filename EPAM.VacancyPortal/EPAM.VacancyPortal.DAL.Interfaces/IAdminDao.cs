using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IAdminDao
    {
        Admin Insert(Admin admin);
        Admin SelectById(int id);
        IEnumerable<Admin> SelectAll();
        int Update(Admin admin);
        int DeleteById(int id);
        void DeleteAll();
    }
}
