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
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeDao _employeeDao;
        private ICityLogic _cityLogic;
        private ISkillLogic _skillLogic;

        public EmployeeLogic(IEmployeeDao employeeDao, ICityLogic cityLogic, ISkillLogic skillLogic)
        {
            _employeeDao = employeeDao;
            _cityLogic = cityLogic;
            _skillLogic = skillLogic;
        }

        public Employee Register(Employee employee)
        {
            int id = _cityLogic.SelectIdByName(employee.City);
            if (id == 0)
            {
                _cityLogic.Insert(new City { Name = employee.City });
            }

            try
            {
                return _employeeDao.Insert(employee);
            }
            catch (SqlException e)
            {
                return employee;
            }
        }

        public Employee SelectByLogin(string login)
        {
            try
            {
                var employee = _employeeDao.SelectByLogin(login);
                employee.Skills = _employeeDao.SelectSkillsByEmployee(employee).ToList();
                return employee;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public Employee SelectById(int id)
        {
            try
            {
                var employee = _employeeDao.SelectById(id);
                employee.Skills = _employeeDao.SelectSkillsByEmployee(employee).ToList();
                return employee;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool Update(Employee employee)
        {
            int id = _cityLogic.SelectIdByName(employee.City);
            if (id == 0)
            {
                _cityLogic.Insert(new City { Name = employee.City });
            }

            try
            {
                return _employeeDao.Update(employee) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool AddSkill(Skill skill,int employeeId)
        {

            var skillExist = _skillLogic.SelectAll().FirstOrDefault(s => s.Name == skill.Name);
            if (skillExist == null)
            {
                skill = _skillLogic.Insert(skill);
            }
            else
            {
                skill.Id = skillExist.Id;
            }

            try
            {
                return _employeeDao.InsertSkill(skill,employeeId) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool UpdateSkill(int id,int level)
        {
            try
            {
                var skill = _employeeDao.SelectSkillById(id);
                skill.Level = level;
                var result = _employeeDao.UpdateSkill(skill);
                return result != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteSkill(int id)
        {
            try
            {
                return _employeeDao.DeleteSkill(id) != 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
