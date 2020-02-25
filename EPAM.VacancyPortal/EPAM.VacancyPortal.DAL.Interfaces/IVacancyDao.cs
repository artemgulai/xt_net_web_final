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
        Vacancy Insert(Vacancy vacancy, Employer employer);
        Vacancy SelectById(int id);
        IEnumerable<Vacancy> SelectAll();
        IEnumerable<Vacancy> SelectAllByEmployer(Employer employer);
        int Update(Vacancy vacancy);
        int DeleteById(int id);
        void DeleteAll();
        int AddRequirement(Skill skill, Vacancy vacancy);
        int RemoveRequirement(Skill skill, Vacancy vacancy);
        IEnumerable<Skill> GetRequirementsByVacancy(Vacancy vacancy);
    }
}
