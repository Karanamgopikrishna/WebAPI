using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeServices.Models;

namespace EmployeeServices.Controllers
{
    public class EmployeesController : ApiController
    {
        //Parameter Binding in WEB Api's
        public HttpResponseMessage Get(string gender = "all")
        {
            using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
            {
                switch (gender.ToLower())
                {
                    case "All":
                        return Request.CreateResponse(HttpStatusCode.OK, dBEntities.Employees.ToList());

                    case "Male":
                        return Request.CreateResponse(HttpStatusCode.OK, dBEntities.Employees.Where(m => m.Gender == "Male").ToList());
                    case "Female":
                        return Request.CreateResponse(HttpStatusCode.OK, dBEntities.Employees.Where(f => f.Gender == "Female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value of Gender must be Male / Female/ All " + gender + " is invalid.");
                }
            }
        }

        //Understanding FromBody and FromUri attributes.
        //public HttpResponseMessage Put(int id,Employee employee)
        //{
        //    try
        //    {
        //        using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
        //        {
        //            var entity = dBEntities.Employees.FirstOrDefault(e=>e.ID==id);
        //            if(entity==null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " is not found");
        //            }
        //            else
        //            {
        //                entity.FirstName = employee.FirstName;
        //                entity.LastName = employee.LastName;
        //                entity.Gender = employee.Gender;
        //                entity.Salary = employee.Salary;

        //                dBEntities.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, employee);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}


            //Default convention used by WEBAPI for Parameter Binding
        public HttpResponseMessage Put([FromBody] int id,[FromUri] Employee employee)
        {
            try
            {
                using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
                {
                    var entity = dBEntities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " is not found");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        dBEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, employee);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}

