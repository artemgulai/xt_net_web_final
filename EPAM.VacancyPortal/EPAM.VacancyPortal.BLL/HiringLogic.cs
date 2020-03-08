using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.BLL
{
    public class HiringLogic : IHiringLogic
    {
        IVacancyLogic _vacancyLogic;
        IEmployeeLogic _employeeLogic;

        public HiringLogic(IVacancyLogic vacancyLogic,IEmployeeLogic employeeLogic)
        {
            _vacancyLogic = vacancyLogic;
            _employeeLogic = employeeLogic;
        }

        // transactional method
        public bool AcceptEmployee(int employeeId,int vacancyId,int responseId)
        {
            bool employeeDeactivated = false;
            bool vacancyDeactivated = false;
            bool responseRemoved = false;

            var employee = _employeeLogic.SelectById(employeeId);
            if(employee == null)
            {
                return false;
            }

            var vacancy = _vacancyLogic.SelectById(vacancyId);
            if(vacancy == null)
            {
                return false;
            }

            employeeDeactivated = _employeeLogic.Deactivate(employeeId);
            if (!employeeDeactivated)
            {
                return false;
            }

            vacancyDeactivated = _vacancyLogic.Deactivate(vacancyId);
            if (!vacancyDeactivated)
            {
                _employeeLogic.Update(employee);
                return false;
            }

            responseRemoved = _employeeLogic.DeleteVacancyResponse(responseId);

            if (!responseRemoved)
            {
                _employeeLogic.Update(employee);
                _vacancyLogic.Update(vacancy);
                return false;
            }

            _employeeLogic.DeleteHiredVacancyResponses(employeeId,vacancyId);
            _vacancyLogic.DeleteHiredEmployeeResponses(employeeId,vacancyId);

            return true;
        }

        public bool DeclineEmployee(int responseId)
        {
            var result = _employeeLogic.DeleteVacancyResponse(responseId);
            return result;
        }

        public bool CheckSkillsRequirementsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements)
        {
            foreach (var req in requirements)
            {
                var skill = skills.FirstOrDefault(s => s.Name == req.Name);
                if (skill == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool AcceptVacancy(int employeeId,int vacancyId,int responseId)
        {
            bool employeeDeactivated = false;
            bool vacancyDeactivated = false;
            bool responseRemoved = false;

            var employee = _employeeLogic.SelectById(employeeId);
            if (employee == null)
            {
                return false;
            }

            var vacancy = _vacancyLogic.SelectById(vacancyId);
            if (vacancy == null)
            {
                return false;
            }

            employeeDeactivated = _employeeLogic.Deactivate(employeeId);
            if (!employeeDeactivated)
            {
                return false;
            }

            vacancyDeactivated = _vacancyLogic.Deactivate(vacancyId);
            if (!vacancyDeactivated)
            {
                _employeeLogic.Update(employee);
                return false;
            }

            responseRemoved = _vacancyLogic.DeleteEmployeeResponse(responseId);

            if (!responseRemoved)
            {
                _employeeLogic.Update(employee);
                _vacancyLogic.Update(vacancy);
                return false;
            }

            _employeeLogic.DeleteHiredVacancyResponses(employeeId,vacancyId);
            _vacancyLogic.DeleteHiredEmployeeResponses(employeeId,vacancyId);

            return true;
        }

        public bool DeclineVacancy(int responseId)
        {
            var result = _vacancyLogic.DeleteEmployeeResponse(responseId);
            return result;
        }

        public bool CheckSkillsRequirementsLevelsVacancyResponse(IEnumerable<Skill> skills,IEnumerable<Skill> requirements)
        {
            foreach (var req in requirements)
            {
                var skill = skills.FirstOrDefault(s => s.Name == req.Name);
                if (skill == null)
                {
                    return false;
                }

                if (req.Level > skill.Level)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
