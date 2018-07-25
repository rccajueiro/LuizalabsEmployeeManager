using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Repositories;
using EmployeeManagerRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerRepository.Repositories
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private DataContext _context;

        public DepartamentRepository()
        {
            _context = new DataContext();
        }

        public void Add(Departament entity)
        {
            _context.Departament.Add(entity);
        }

        public int Count()
        {
            return _context.Departament.Count();
        }

        public void Delete(Departament entity)
        {
            _context.Departament.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Departament entity)
        {
            _context.Entry<Departament>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public Departament Get(int id)
        {
            return _context.Departament.Find(id);
        }

        public List<Departament> GetAll()
        {
            return _context.Departament.ToList();
        }

        public List<Departament> List(int page_size, int page)
        {
            throw new NotImplementedException();
        }

        public void Save(Departament entity)
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
            Dispose();
        }

        public Departament SaveIfNotExists(Departament departament)
        {
            var match = from d in _context.Departament
                        where d.Name.Equals(departament.Name)
                        select d;

            if(match.Count() > 0)
            {
                return match.First();
            }

            Save(departament);

            return departament;
        }
    }
}
