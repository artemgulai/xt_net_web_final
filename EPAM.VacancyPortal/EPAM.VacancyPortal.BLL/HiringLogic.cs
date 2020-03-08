using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.DAL.Interfaces;
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

            // удаление всех отзывов с принятым работником
            // удаление всех отзывов с принятой вакансией

            return true;
        }
    }
}
