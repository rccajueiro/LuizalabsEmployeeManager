using System;
using EmployeeManagerAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagerAPI.Models;
using System.Collections.Generic;
using System.Net;
using EmployeeManagerServices.Services;
using EmployeeManagerEngine.Services;
using EmployeeManagerEngine.Entities;
using EmployeeManagerCommon.Validations;

namespace EmployeeManagerAPITest.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private readonly EmployeeController _controller;

        public EmployeeControllerTest()
        {
            _controller = new EmployeeController();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void ListTestOk()
        {
            _controller.Request = new HttpRequestMessage();

            var result = _controller.Get();
            var contentResult = result as NegotiatedContentResult<ICollection<EmployeeModel>>;

            Assert.IsNotNull(contentResult);
            Equals(contentResult.Content.Count > 0);
            Assert.AreEqual(HttpStatusCode.OK, contentResult.StatusCode);
        }

        [TestMethod]
        public void PostTestOk()
        {
            string name = "Ricardo Cajueiro";
            string email = "ricardo@rcajueiro.eti.br";
            string departament = "Information Technology";

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Post(new EmployeeModel()
            { 
                Name = name,
                Email = email,
                Departament = departament
            });

            var createdResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("", createdResult.Content);
            Assert.AreEqual(HttpStatusCode.Created, createdResult.StatusCode);
        }

        [TestMethod]
        public void PostTestNameRequired()
        {
            string name = "";
            string email = "ricardo@rcajueiro.eti.br";
            string departament = "Information Technology";

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Post(new EmployeeModel()
            {
                Name = name,
                Email = email,
                Departament = departament
            });

            var createdResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(createdResult);
            Assert.IsTrue(createdResult.Content.Contains(Employee.EXCEPTION_MESSAGE_EMPLOYEE_NAME_REQUIRED));
            Assert.AreEqual(HttpStatusCode.InternalServerError, createdResult.StatusCode);
        }

        [TestMethod]
        public void PostTestEmailRequired()
        {
            string name = "Ricardo Cajueiro";
            string email = "";
            string departament = "Information Technology";

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Post(new EmployeeModel()
            {
                Name = name,
                Email = email,
                Departament = departament
            });

            var createdResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(createdResult);
            Assert.IsTrue(createdResult.Content.Contains(Employee.EXCEPTION_MESSAGE_EMPLOYEE_EMAIL_REQUIRED));
            Assert.AreEqual(HttpStatusCode.InternalServerError, createdResult.StatusCode);
        }

        [TestMethod]
        public void PostTestDepartamentRequired()
        {
            string name = "Ricardo Cajueiro";
            string email = "ricardo@rcajueiro.eti.br";
            string departament = "";

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Post(new EmployeeModel()
            {
                Name = name,
                Email = email,
                Departament = departament
            });

            var createdResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(createdResult);
            Assert.IsTrue(createdResult.Content.Contains(Departament.EXCEPTION_MESSAGE_DEPARTAMENT_NAME_REQUIRED));
            Assert.AreEqual(HttpStatusCode.InternalServerError, createdResult.StatusCode);
        }

        [TestMethod]
        public void PostTestEmailIsNotValid()
        {
            string name = "Ricardo Cajueiro";
            string email = "test.email.is.not.valid";
            string departament = "Information Technology";

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Post(new EmployeeModel()
            {
                Name = name,
                Email = email,
                Departament = departament
            });

            var createdResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual(EmailValidation.EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID, createdResult.Content);
            Assert.AreEqual(HttpStatusCode.InternalServerError, createdResult.StatusCode);
        }

        [TestMethod]
        public void DeleteTestOk()
        {
            IEmployeeService _employeeService = new EmployeeService();
            var employees = _employeeService.List(1, 1);
            Employee employee = employees[0];

            _controller.Request = new HttpRequestMessage();
            var result = _controller.Delete(employee.Id);
            var deletedResult = result as NegotiatedContentResult<string>;

            Assert.IsNotNull(deletedResult);
            Assert.AreEqual("", deletedResult.Content);
            Assert.AreEqual(HttpStatusCode.OK, deletedResult.StatusCode);
        }
    }
}
