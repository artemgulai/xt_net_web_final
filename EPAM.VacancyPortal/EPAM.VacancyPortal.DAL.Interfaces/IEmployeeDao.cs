using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IEmployeeDao
    {
        Employee Insert(Employee employee);
        Employee SelectById(int id);
        IEnumerable<Employee> SelectAll();
        int Update(Employee employee);
        int DeleteById(int id);
        void DeleteAll();
        int AddSkill(Skill skill);
        int RemoveSkill(Skill skill);
    }
}
