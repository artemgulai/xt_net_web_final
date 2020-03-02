using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IEmployeeLogic
    {
        Employee Register(Employee employee);
        Employee SelectByLogin(string login);
        Employee SelectById(int id);
        bool Update(Employee employee);
        bool AddSkill(Skill skill,int employeeId);
        bool UpdateSkill(int skillId,int level);
        bool DeleteSkill(int skillId);
    }
}
