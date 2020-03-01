using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IVacancyLogic
    {
        Vacancy Insert(Vacancy vacancy);
        IEnumerable<Vacancy> SelectByEmployer(Employer employer);
        Vacancy SelectById(int id);
        bool Update(Vacancy vacancy);
    }
}
