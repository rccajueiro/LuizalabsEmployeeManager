using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>, IDisposable
    {
    }
}
