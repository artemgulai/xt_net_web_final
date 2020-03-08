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
    public class VacancyLogic : IVacancyLogic
    {
        private IVacancyDao _vacancyDao;
        private ISkillLogic _skillLogic;
        private IResponseDao _responseDao;
        public VacancyLogic(IVacancyDao vacancyDao, 
                            ISkillLogic skillLogic,
                            IResponseDao responseDao)
        {
            _vacancyDao = vacancyDao;
            _skillLogic = skillLogic;
            _responseDao = responseDao;

        }

        public Vacancy Insert(Vacancy vacancy)
        {
            try
            {
                return _vacancyDao.Insert(vacancy);
            }
            catch (SqlException)
            {
                return vacancy;
            }
        }

        public IEnumerable<Vacancy> SelectByEmployer(Employer employer)
        {
            try
            {
                return _vacancyDao.SelectAllByEmployer(employer);
            }
            catch (SqlException)
            {
                return new Vacancy[] { };
            }
        }

        public Vacancy SelectById(int id)
        {
            try
            {
                var vacancy = _vacancyDao.SelectById(id);
                vacancy.Requirements = _vacancyDao.SelectRequirementsByVacancy(vacancy).ToList();
                return vacancy;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool Update(Vacancy vacancy)
        {
            try
            {
                return _vacancyDao.Update(vacancy) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                return _vacancyDao.DeleteById(id) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool Activate(int id)
        {
            var vacancy = SelectById(id);
            vacancy.Active = true;
            var result = Update(vacancy);
            return result;
        }

        public bool Deactivate(int id)
        {
            var vacancy = SelectById(id);
            vacancy.Active = false;
            var result = Update(vacancy);
            return result;
        }

        public bool UpdateRequirement(int id,int level)
        {
            try
            {
                var requirement = _vacancyDao.SelectRequirementById(id);
                requirement.Level = level;
                var result = _vacancyDao.UpdateRequirement(requirement);
                return result != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool AddRequirement(Skill requirement,int vacancyId)
        {
            var skillExist = _skillLogic.SelectAll().FirstOrDefault(r => r.Name == requirement.Name);
            if (skillExist == null)
            {
                requirement = _skillLogic.Insert(requirement);
            }
            else
            {
                requirement.Id = skillExist.Id;
            }

            try
            {
                return _vacancyDao.InsertRequirement(requirement,vacancyId) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteRequirement(int id)
        {
            try
            {
                return _vacancyDao.DeleteRequirement(id) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool InsertEmployeeResponse(int employeeId,int vacancyId,int employerId)
        {
            try
            {
                return _responseDao.InsertEmployeeResponse(employeeId,vacancyId, employerId) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteEmployeeResponse(int id)
        {
            try
            {
                return _responseDao.DeleteEmployeeResponse(id) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public IEnumerable<Response> SelectAllEmployeeResponses()
        {
            try
            {
                return _responseDao.SelectAllEmployeeResponses();
            }
            catch (SqlException)
            {
                return new List<Response>();
            }
        }
    }
}
