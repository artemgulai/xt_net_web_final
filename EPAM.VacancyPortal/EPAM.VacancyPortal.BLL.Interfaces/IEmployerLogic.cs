using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IEmployerLogic
    {
        Employer Register(Employer employer);
        Employer SelectByLogin(string login);
        Employer SelectById(int id);
        IEnumerable<Employer> SelectAll();
        bool Update(Employer employer);
        bool Delete(int id);
        bool SignIn(string login,string password);
    }
}
