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
        int InsertEmployeeResponse(int employeeId,int vacancyId,int employerId);
        int DeleteEmployeeResponse(int id);
        IEnumerable<Response> SelectAllEmployeeResponses();
        IEnumerable<Response> SelectAllVacancyResponses();
    }
}
