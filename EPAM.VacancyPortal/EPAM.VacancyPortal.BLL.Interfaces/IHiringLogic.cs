using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL.Interfaces
{
    public interface IHiringLogic
    {
        bool AcceptEmployee(int employeeId,int vacancyId,int responseId);
        bool DeclineEmployee(int responseId);

        bool AcceptVacancy(int employeeId,int vacancyId,int responseId);
        bool DeclineVacancy(int responseId);

        bool CheckSkillsRequirementsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements);
        bool CheckSkillsRequirementsLevelsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements);
    }
}
