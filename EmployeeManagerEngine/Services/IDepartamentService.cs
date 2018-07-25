using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Services
{
    public interface IDepartamentService
    {
        Departament SaveIfNotExists(Departament departament);
    }
}
