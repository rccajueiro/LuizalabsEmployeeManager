using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Services
{
    public interface IEmployeeService
    {
        List<Employee> List(int page_size, int page);
        void Create(Employee employee);
        void Delete(int id);
    }
}
