using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IVacancyDao
    {
        Vacancy Insert(Vacancy vacancy, int employerId);
        Vacancy SelectById(int id);
        IEnumerable<Vacancy> SelectAll();
        IEnumerable<Vacancy> SelectAllByEmployer(int employerId);
        int Update(Vacancy vacancy);
        int DeleteById(int id);
        void DeleteAll();
        int AddRequirement(Skill skill);
        int RemoveRequirement(Skill skill);
    }
}
