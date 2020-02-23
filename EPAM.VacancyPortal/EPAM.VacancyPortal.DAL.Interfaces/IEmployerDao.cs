using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IEmployerDao
    {
        Employer Insert(Employer employer);
        Employer SelectById(int id);
        IEnumerable<Employer> SelectAll();
        int Update(Employer employer);
        int DeleteById(int id);
        void DeleteAll();
    }
}
