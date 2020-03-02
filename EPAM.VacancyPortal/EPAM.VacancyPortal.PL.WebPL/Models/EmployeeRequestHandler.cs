﻿using EPAM.VacancyPortal.BLL.Interfaces;
using EPAM.VacancyPortal.Entities;
using EPAM.VacancyPortal.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.VacancyPortal.PL.WebPL.Models
{
    public static class EmployeeRequestHandler
    {
        private static IEmployeeLogic _employeeLogic;
        private static ICommonLogic _commonLogic;

        static EmployeeRequestHandler()
        {
            _employeeLogic = DependencyManager.Instance.EmployeeLogic;
            _commonLogic = DependencyManager.Instance.CommonLogic;
        }

        public static void Register(HttpRequestBase req, HttpResponseBase res)
        {
            string firstName = req["firstName"];
            string lastName = req["lastName"];
            string city = req["city"];
            bool relocation = req["relocation"] == "true";
            string login = req["login"];
            string password = req["password"];
            var image = req.Files["image"];

            if (!_commonLogic.CheckLogin(login))
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Login occupied.")));
                return;
            }

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                City = city,
                Relocation = relocation,
                Login = login,
                Password = password,
                Photo = string.Empty
            };

            if (image != null && image.ContentLength != 0)
            {
                var bytes = new byte[image.ContentLength];
                image.InputStream.Read(bytes,0,bytes.Length);
                employee.Photo= Convert.ToBase64String(bytes);
            }

            employee = _employeeLogic.Register(employee);
            if (employee.Id == 0)
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

        public static bool CheckRole(string login,string roleName)
        {
            var employee = _employeeLogic.SelectByLogin(login);
            return employee != null && employee.Role == roleName;
        }

        public static Employee SelectByLogin(string login)
        {
            return _employeeLogic.SelectByLogin(login);
        }

        public static void SignIn(HttpRequestBase req,HttpResponseBase res)
        {
            string login = req["login"];
            string password = req["password"];

            var employee = _employeeLogic.SelectByLogin(login);

            if (employee != null)
            {
                if (employee.Password == password)
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
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","No employee with such login.")));
                return;
            }
        }

        public static void Update(HttpRequestBase req,HttpResponseBase res)
        {
            int id = int.Parse(req["id"]);
            string firstName = req["firstName"];
            string lastName = req["lastName"];
            string city = req["city"];
            bool relocation = req["relocation"] == "true";
            string password = req["password"];
            var image = req.Files["image"];

            var employee = _employeeLogic.SelectById(id);
            if (employee == null)
            {
                res.Write(JsonConvert.SerializeObject
                    (
                        new RequestResult("Error","No such employee in Database")
                    ));
                return;
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                employee.FirstName = firstName;
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                employee.LastName = lastName;
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                employee.City = city;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                employee.Password = password;
            }

            if (relocation ^ employee.Relocation)
            {
                employee.Relocation = relocation;
            }

            if (image != null && image.ContentLength != 0)
            {
                var bytes = new byte[image.ContentLength];
                image.InputStream.Read(bytes,0,bytes.Length);
                employee.Photo = Convert.ToBase64String(bytes);
            }

            if (_employeeLogic.Update(employee))
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Profile has been updated.")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Profile cannot be updated.")));
            }
        }

        public static RequestResult AddSkill(Skill skill, int employeeId)
        {
            var result = _employeeLogic.AddSkill(skill,employeeId);
            if (result)
            {
                return new RequestResult("Success","Skill has been added.");
            }
            else
            {
                return new RequestResult("Error","Cannot add skill.");
            }
        }

        public static void UpdateSkillLevel(HttpRequestBase req,HttpResponseBase res)
        {
            var id = int.Parse(req["id"]);
            var level = int.Parse(req["level"]);
            var result = _employeeLogic.UpdateSkill(id,level);
            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Level has been changed.")));
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Cannot change level.")));
            }
        }

        public static void DeleteSkill(HttpRequestBase req,HttpResponseBase res)
        {
            var result = _employeeLogic.DeleteSkill(int.Parse(req["id"]));
            if (result)
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Success","Skill has been deleted.")));
                return;
            }
            else
            {
                res.Write(JsonConvert.SerializeObject(new RequestResult("Error","Cannot delete skill.")));
                return;
            }
        }
    }
}