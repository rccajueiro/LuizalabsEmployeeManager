using EmployeeManagerCommon.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerEngine.Entities
{
    public class Employee
    {
        public const string EXCEPTION_MESSAGE_EMPLOYEE_NAME_REQUIRED = "Name is required";
        public const string EXCEPTION_MESSAGE_EMPLOYEE_EMAIL_REQUIRED = "E-mail is required";
        public const string EXCEPTION_MESSAGE_EMPLOYEE_DEPARTAMENT_REQUIRED = "Departament is required";

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int DepartamentId { get; private set; }

        public virtual Departament Departament { get; private set; }

        private Employee() { }

        public Employee (string name, string email, Departament departament)
        {
            GenericValidation.StringIsNullOrEmpty(name, EXCEPTION_MESSAGE_EMPLOYEE_NAME_REQUIRED);
            GenericValidation.StringIsNullOrEmpty(email, EXCEPTION_MESSAGE_EMPLOYEE_EMAIL_REQUIRED);
            EmailValidation.IsValid(email);
            GenericValidation.ObjectIsNull(departament, EXCEPTION_MESSAGE_EMPLOYEE_DEPARTAMENT_REQUIRED);

            Name = name;
            Email = email;
            DepartamentId = departament.Id;
            Departament = departament;
        }
    }
}
