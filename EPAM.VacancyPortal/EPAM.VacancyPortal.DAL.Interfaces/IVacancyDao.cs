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
        Vacancy Insert(Vacancy vacancy);
        Vacancy SelectById(int id);
        IEnumerable<Vacancy> SelectAll();
        IEnumerable<Vacancy> SelectAllByEmployer(Employer employer);
        int Update(Vacancy vacancy);
        int DeleteById(int id);
        void DeleteAll();
        int InsertRequirement(Skill skill, Vacancy vacancy);
        int DeleteRequirement(Skill skill, Vacancy vacancy);
        IEnumerable<Skill> SelectRequirementsByVacancy(Vacancy vacancy);
    }
}
