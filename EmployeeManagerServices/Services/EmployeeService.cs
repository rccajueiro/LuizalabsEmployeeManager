using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Repositories;
using EmployeeManagerEngine.Services;
using EmployeeManagerRepository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeManagerServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public void Create(Employee employee)
        {
            _repository.Save(employee);
        }

        public List<Employee> List(int page_size, int page)
        {
            return _repository.List(page_size, page);
        }

        public void Delete(int id)
        {
            var employee = _repository.Get(id);

            _repository.Delete(employee);
        }
    }
}