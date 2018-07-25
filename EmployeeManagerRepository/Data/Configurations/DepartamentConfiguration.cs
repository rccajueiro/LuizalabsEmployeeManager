using EmployeeManagerEngine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerRepository.Data.Configurations
{
    public class DepartamentConfiguration : EntityTypeConfiguration<Departament>
    {
        public DepartamentConfiguration()
        {
            HasKey(departament => departament.Id);

            Property(departament => departament.Name)
                .IsRequired();
        }
    }
}
