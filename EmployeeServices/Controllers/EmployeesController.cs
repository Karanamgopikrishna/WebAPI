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
        //public IEnumerable<Employee> Get()
        //{
        //    using(EmployeeDBContext dbContext =new EmployeeDBContext())
        //    {
        //        return dbContext.Employees.ToList();
        //    }
        //}

        //public Employee Get(int id)
        //{
        //    using(EmployeeDBContext dBContext=new EmployeeDBContext())
        //    {
        //        return dBContext.Employees.FirstOrDefault(e => e.ID == id);
        //    }
        //}

        //----------------------------------------------------------------------------------------//

        //public IEnumerable<string> Get()
        //{
        //    IList<string> formatters = new List<string>();
        //    foreach(var item in GlobalConfiguration.Configuration.Formatters)
        //    {
        //        formatters.Add(item.ToString());
        //    }
        //    return formatters.AsEnumerable<string>();
        //}


        //Methods with GET()
        //public HttpResponseMessage Get()
        //{
        //    using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
        //    {
        //        var Employees = dBContext.Employees.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Employees);
        //    }
        //}

        //----------------------------------------------------------------------------------------//




        //Methods with [HttpGET] attribute
        //public HttpResponseMessage LoadEmployees()
        //{
        //    using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
        //    {
        //        var Employees = dBContext.Employees.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Employees);
        //    }
        //}




        //Methods with Get(paramaeter)
        //public HttpResponseMessage Get(int id)
        //{
        //    using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
        //    {
        //        var entity = dBContext.Employees.FirstOrDefault(d => d.ID == id);
        //        if(entity!=null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID :" + id.ToString() + "is not found");
        //        }
        //    }
        //}



           //-----Methods with parameters [HttpGet] attribute---------//
        //public HttpResponseMessage LoadEmployeeByID(int id)
        //{
        //    using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
        //    {
        //        var entity = dBContext.Employees.FirstOrDefault(d => d.ID == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID :" + id.ToString() + "is not found");
        //        }
        //    }
        //}


        //----------------------------------------------------------------------------------------//



        //Implementing multiple GET,PUT,POST,DELETE methods with in single controller for below two methods
        //[HttpGet]
        //public HttpResponseMessage LoadAllEmployees()
        //{
        //    using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
        //    {
        //        var Employees = dBEntities.Employees.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Employees);
        //    }
        //}

        //[HttpGet]
        //public HttpResponseMessage LoadAllMaleEmployees()
        //{
        //    using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
        //    {
        //        var Employees = dBEntities.Employees.Where(m => m.Gender == "Male").ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Employees);
        //    }
        //}

        //[HttpGet]
        //public HttpResponseMessage LoadAllFemaleEmployees()
        //{
        //    using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
        //    {
        //        var Employees = dBEntities.Employees.Where(f => f.Gender == "Female").ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Employees);
        //    }
        //}



        //----------------------------------------------------------------------------------------//




        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EF_Demo_DBEntities dbContext = new EF_Demo_DBEntities())
                {
                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());

                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Put(int id, [FromBody]Employee employee )
        {
            try
            {
                using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
                {
                    var entity = dBEntities.Employees.FirstOrDefault(e => e.ID == id);
                    if(entity==null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " not found to update");

                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        dBEntities.SaveChanges();


                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        public HttpResponseMessage Delete(int id)
        {
            using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
            {

                try
                {
                    var entity = dBEntities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID:" + id.ToString() + " is not found to delete");
                    }
                    else
                    {
                        dBEntities.Employees.Remove(entity);
                        dBEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                
            }
        }


    }
}
