using EmployeeManagerCommon.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Entities
{
    public class Departament
    {
        public const string EXCEPTION_MESSAGE_DEPARTAMENT_NAME_REQUIRED = "Name is required";

        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Employee> Employees { get; set; }

        private Departament() { }

        public Departament(string name)
        {
            GenericValidation.StringIsNullOrEmpty(name, EXCEPTION_MESSAGE_DEPARTAMENT_NAME_REQUIRED);

            Name = name;
        }
    }
}
