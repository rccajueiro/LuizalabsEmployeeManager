using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerRepository.Data.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(employee => employee.Id);

            Property(employee => employee.Name)
                    .IsRequired();

            Property(employee => employee.Email)
                    .IsRequired();

            HasRequired(employee => employee.Departament)
                .WithMany(departament => departament.Employees)
                .HasForeignKey(employee => employee.DepartamentId);
        }
    }
}
