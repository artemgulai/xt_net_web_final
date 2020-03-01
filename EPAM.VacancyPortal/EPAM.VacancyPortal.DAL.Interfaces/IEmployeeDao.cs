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
        Employee SelectByLogin(string login);
        IEnumerable<Employee> SelectAll();
        int Update(Employee employee);
        int DeleteById(int id);
        void DeleteAll();
        int InsertSkill(Skill skill, Employee employee);
        int DeleteSkill(Skill skill, Employee employee);
        int UpdateSkill(Skill skill, Employee employee);
        IEnumerable<Skill> SelectSkillsByEmployee(Employee employee);
    }
}
