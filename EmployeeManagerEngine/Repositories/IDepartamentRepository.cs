using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Repositories
{
    public interface IDepartamentRepository : IGenericRepository<Departament>, IDisposable
    {
        Departament SaveIfNotExists(Departament departament);
    }
}
