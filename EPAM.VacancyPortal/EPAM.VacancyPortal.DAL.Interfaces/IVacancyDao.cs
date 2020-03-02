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
        int InsertRequirement(Skill skill, int vacancyId);
        int DeleteRequirement(int id);
        Skill SelectRequirementById(int id);
        int UpdateRequirement(Skill skill);
        IEnumerable<Skill> SelectRequirementsByVacancy(Vacancy vacancy);
    }
}
