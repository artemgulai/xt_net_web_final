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
    public class SkillLogic : ISkillLogic
    {
        private ISkillDao _skillDao;
        public SkillLogic(ISkillDao skillDao)
        {
            _skillDao = skillDao;
        }

        public int DeleteById(int id)
        {
            try
            {
                return _skillDao.DeleteById(id);
            }
            catch
            {
                return 0;
            }

        }

        public IEnumerable<Skill> SelectAll()
        {
            try
            {
                return _skillDao.SelectAll();
            }
            catch
            {
                return new List<Skill>();
            }
        }

        public Skill Insert(Skill skill)
        {
            try
            {
                return _skillDao.Insert(skill);
            }
            catch
            {
                return skill;
            }
        }
    }
}
