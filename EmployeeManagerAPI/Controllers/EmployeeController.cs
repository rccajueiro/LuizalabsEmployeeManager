using EmployeeManagerAPI.Models;
using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Services;
using EmployeeManagerServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagerAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartamentService _departamentService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
            _departamentService = new DepartamentService();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try { 
                var pairs = this.Request.GetQueryNameValuePairs();
                int page = 1, page_size = 10;

                foreach (var item in pairs)
                {
                    if(item.Key == "page")
                    {
                        page = int.Parse(item.Value);
                    }

                    if (item.Key == "page_size")
                    {
                        page_size = int.Parse(item.Value);
                    }
                }

                if (page < 1) throw new ArgumentOutOfRangeException();
                if (page_size < 1) throw new ArgumentOutOfRangeException();

                ICollection<EmployeeModel> employees = new List<EmployeeModel>();

                foreach(Employee employee in _employeeService.List(page_size, page))
                {
                    employees.Add(new EmployeeModel()
                    {
                        Name = employee.Name,
                        Email = employee.Email,
                        Departament = employee.Departament.Name
                    });
                }

                if (employees.Count == 0) throw new ArgumentNullException();

                return Content(HttpStatusCode.OK, employees);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]EmployeeModel employeeModel)
        {
            try
            {
                Departament departament = new Departament(employeeModel.Departament);
                departament = _departamentService.SaveIfNotExists(departament);

                Employee employee = new Employee(employeeModel.Name, employeeModel.Email, departament);
                _employeeService.Create(employee);

                return Content(HttpStatusCode.Created, "");
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            { 
                _employeeService.Delete(id);

                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}