using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.VacancyPortal.DAL.Interfaces
{
    public interface IResponseDao
    {
        int InsertVacancyResponse(int vacancyId,int employeeId);
        int DeleteVacancyResponse(int id);
        int InsertEmployeeResponse(int vacancyId,int employeeId);
        int DeleteEmployeeResponse(int id);
    }
}
