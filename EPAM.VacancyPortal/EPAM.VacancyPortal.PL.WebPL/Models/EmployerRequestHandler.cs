using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class EmployerRequestHandler
    {
        private static IEmployerLogic _employerLogic;
        private static ICommonLogic _commonLogic;

        static EmployerRequestHandler()
        {
            _employerLogic = DependencyManager.Instance.EmployerLogic;
            _commonLogic = DependencyManager.Instance.CommonLogic;
        }
        
        public static void Register(HttpRequestBase req, HttpResponseBase res)
        {
            string name = req["name"];
            string city = req["city"];
            string login = req["login"];
            string password = req["password"];
            var image = req.Files["image"];

            if (!_commonLogic.CheckLogin(login))
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Login occupied.")));
                return;
            }

            var employer = new Employer
            {
                Name = name,
                City = city,
                Login = login,
                Password = password,
                Logo = string.Empty
            };

            if (image != null && image.ContentLength != 0)
            {
                var bytes = new byte[image.ContentLength];
                image.InputStream.Read(bytes,0,bytes.Length);
                employer.Logo = Convert.ToBase64String(bytes);
            }

            employer = _employerLogic.Register(employer);
            if (employer.Id == 0)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Something went wrong.")));
                return;
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Successfully registered.")));
                return;
            }
        }

        public static void SignIn(HttpRequestBase req,HttpResponseBase res)
        {
            string login = req["login"];
            string password = req["password"];

            var employer = _employerLogic.SelectByLogin(login);

            if (employer != null)
            {
                if (employer.Password == password)
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
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","No employer with such login.")));
                return;
            }
        }

        public static void Update(HttpRequestBase req, HttpResponseBase res)
        {
            int id = int.Parse(req["id"]);
            string name = req["name"];
            string city = req["city"];
            string password = req["password"];
            var image = req.Files["image"];

            var employer = _employerLogic.SelectById(id);
            if (employer == null)
            {
                res.Write(JsonConvert.SerializeObject
                    (
                        new RequestResult("error", "No such employer in Database")
                    ));
                return;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                employer.Name = name;
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                employer.City = city;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                employer.Password = password;
            }

            if (image != null && image.ContentLength != 0)
            {
                var bytes = new byte[image.ContentLength];
                image.InputStream.Read(bytes,0,bytes.Length);
                employer.Logo = Convert.ToBase64String(bytes);
            }
            
            if (_employerLogic.Update(employer))
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Profile has been updated.")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Profile cannot be updated.")));
            }
        }

        public static void DeleteRequest(HttpRequestBase req,HttpResponseBase res)
        {
            int id = int.Parse(req["id"]);
            EmployerService.Delete(id);
            res.Write(JsonConvert.SerializeObject(
                new
                {
                    Result = "success",
                    Message = "Profile has been deleted"
                }
            ));
        }
    }
}