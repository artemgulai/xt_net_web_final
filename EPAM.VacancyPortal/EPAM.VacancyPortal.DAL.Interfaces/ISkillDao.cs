using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface ISkillDao
    {
        Skill Insert(Skill skill);
        IEnumerable<Skill> GetAll();
        void DeleteById(int id);
    }
}
