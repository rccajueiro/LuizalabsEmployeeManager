using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Repositories;
using EmployeeManagerEngine.Services;
using EmployeeManagerRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerServices.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentService()
        {
            _repository = new DepartamentRepository();
        }
        public Departament SaveIfNotExists(Departament departament)
        {
            return _repository.SaveIfNotExists(departament);
        }
    }
}
