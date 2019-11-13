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


        //public IEnumerable<string> Get()
        //{
        //    IList<string> formatters = new List<string>();
        //    foreach(var item in GlobalConfiguration.Configuration.Formatters)
        //    {
        //        formatters.Add(item.ToString());
        //    }
        //    return formatters.AsEnumerable<string>();
        //}

        public HttpResponseMessage Get()
        {
            using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
            {
                var Employees = dBContext.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, Employees);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (EF_Demo_DBEntities dBContext = new EF_Demo_DBEntities())
            {
                var entity = dBContext.Employees.FirstOrDefault(d => d.ID == id);
                if(entity!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID :" + id.ToString() + "is not found");
                }
            }
        }


    }
}
