using EPAM.VacancyPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IResponseDao
    {
        int InsertVacancyResponse(int employeeId,int vacancyId);
        int DeleteVacancyResponse(int id);
        int InsertEmployeeResponse(int employeeId,int vacancyId);
        int DeleteEmployeeResponse(int id);
        IEnumerable<Response> SelectAllEmployeeResponses();
        IEnumerable<Response> SelectAllVacancyResponses();
        int DeleteHiredVacancyResponses(int employeeId, int vacancyId);
        int DeleteHiredEmployeeResponses(int employeeId, int vacancyId);
    }
}
