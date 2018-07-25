using System;
using EmployeeManagerEngine.Entities;
using EmployeeManagerEngine.Repositories;
using EmployeeManagerRepository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagerRepositoryTest.Repositories
{
    [TestClass]
    public class DepartamentRepositoryTest
    {
        [TestMethod]
        public void SaveIfNotExistsTest()
        {
            IDepartamentRepository departamentRepository = new DepartamentRepository();
            Departament departament = new Departament("Digital Platform");
            departament = departamentRepository.SaveIfNotExists(departament);
        }
    }
}
