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


        public IEnumerable<string> Get()
        {
            IList<string> formatters = new List<string>();
            foreach(var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }
            return formatters.AsEnumerable<string>();
        }
    }
}
