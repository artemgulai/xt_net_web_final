using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class AdminRequestHandler
    {
        private static IAdminLogic _adminLogic;
        private static ICommonLogic _commonLogic;
        private static SHA256 _sha256;

        static AdminRequestHandler()
        {
            _adminLogic = DependencyManager.Instance.AdminLogic;
            _commonLogic = DependencyManager.Instance.CommonLogic;
            _sha256 = new SHA256Cng();
        }

        public static bool CheckRole(string login,string roleName)
        {
            var admin = _adminLogic.SelectByLogin(login);
            return admin != null && admin.Role == roleName;
        }

        public static void Register(HttpRequestBase req,HttpResponseBase res)
        {
            string login = req["login"];
            string password = req["password"];

            if (!_commonLogic.CheckLogin(login))
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error", "Login occupied")));
                return;
            }

            var registeredAdmin = _adminLogic.Register(new Admin
            {
                Login = login,
                Password = Convert.ToBase64String(_sha256.ComputeHash(Encoding.Unicode.GetBytes(password))),
                IsCandidate = true,
                Role = "ADMIN"
            });

            if (registeredAdmin.Id == 0)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Database error")));
                return;
                // TODO подумать над перенаправлением отсюда на Error Page
            }


            res.Write(JsonConvert.SerializeObject(new RequestResult("Success",
                "You have been registered as Administrator. Wait for verification by administrators.")));
            return;
        }

        public static void SignIn(HttpRequestBase req, HttpResponseBase res)
        {
            string login = req["login"];
            string password = req["password"];

            var admin = _adminLogic.SelectByLogin(login);

            if (admin != null)
            {
                if(admin.Password == Convert.ToBase64String(_sha256.ComputeHash(Encoding.Unicode.GetBytes(password))))
                {
                    res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Succesfully signed in.")));
                    return;
                }
                else
                {
                    res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Wrong password.")));
                    return;
                }
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","No admin with such login.")));
                return;
            }
        }

        public static Admin SelectByLogin(string login)
        {
            return _adminLogic.SelectByLogin(login);
        }
    }
}