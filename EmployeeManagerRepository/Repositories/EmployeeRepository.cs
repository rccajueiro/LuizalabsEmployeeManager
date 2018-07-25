using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Repositories;
using EmployeeManagerRepository.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerRepository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DataContext _context;

        public EmployeeRepository()
        {
            _context = new DataContext();
        }

        public void Add(Employee entity)
        {
            _context.Employee.Add(entity);
        }

        public int Count()
        {
            return _context.Employee.Count();
        }

        public void Delete(Employee entity)
        {
            _context.Employee.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Employee entity)
        {
            _context.Entry<Employee>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public Employee Get(int id)
        {
            return _context.Employee
                .Find(id);
        }

        public List<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }

        public List<Employee> List(int page_size, int page)
        {
            page = page - 1;

            return _context.Employee
                .OrderBy(employee => employee.Name)
                .Skip(page * page_size)
                .Take(page_size)
                .Include(departament => departament.Departament)
                .ToList();
        }

        public void Save(Employee entity)
        {
            if(entity.Id > 0)
            {
                Edit(entity);
            }
            else
            {
                Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
