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
    }
}
