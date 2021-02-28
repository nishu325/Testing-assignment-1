using CPM.BAL.Interface;
using CPM.DAL.Repository;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment.Controllers;
using CPM.Models;
using Xunit;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace CPM.TestProject
{
    public class TestCustomerController
    {
        private readonly Mock<ICustomerDetail> mockData = new Mock<ICustomerDetail>();

        private readonly CustomerController _customerController;
        public TestCustomerController()
        {
            _customerController = new CustomerController(mockData.Object);

        }


        [Fact]
        public void TestPositive_GetCustomerList()
        {
            var result = mockData.Setup(m => m.GetCustomerList()).Returns(GetCustomer());
            var response = _customerController.Get();
            Assert.Equal(2, response.Count);
        }
        [Fact]
        public void TestNegative_GetCustomerList()
        {
            var result = mockData.Setup(m => m.GetCustomerList()).Equals(null);
            var response = _customerController.Get();
            Assert.Null(response);
        }
        [Fact]
        public void TestPositive_AddNewCustomer()
        {
            var newUser = new Customer();
            newUser.Id = 1;
            newUser.Customer_First_Name = "nishu";
            newUser.Customer_Last_Name = "patel";
            newUser.Customer_Phone_Number = "9685741230";
            var response = mockData.Setup(m => m.AddNewCustomer(newUser)).Returns(AddCustomer());
            var result = _customerController.Post(newUser);
            Assert.NotNull(result);
        }
        [Fact]
        public void TestNegative_AddNewCustomer()
        {
            var newUser = new Customer();
            newUser.Id = -1;
            newUser.Customer_First_Name = null;
            newUser.Customer_Last_Name = null;
            newUser.Customer_Phone_Number = null;
            var response = mockData.Setup(m => m.AddNewCustomer(newUser)).Equals(null);
            var result = _customerController.Post(newUser);
            Assert.Null(result);
        }
        [Fact]
        public void TestPositive_UpdateCustomer()
        {
            var model = JsonConvert.DeserializeObject<Customer>(File.ReadAllText("UpdateData/UpdateCustomerData.json"));
            var resultObj = mockData.Setup(m => m.UpdateCustomer(model, model.Id)).Returns(model);
            var response = _customerController.Put(model, model.Id);
            Assert.Equal(model, response);
        }
        [Fact]
        public void TestNegative_UpdateCustomer()
        {
            var model = JsonConvert.DeserializeObject<Customer>(File.ReadAllText("UpdateData/UpdateCustomerData.json"));
            var resultObj = mockData.Setup(m => m.UpdateCustomer(model, model.Id)).Equals(null);
            var response = _customerController.Put(model, model.Id);
            Assert.NotEqual(model, response);
        }
        [Fact]
        public void TestPositive_DeleteCustomer()
        {
            var customer = new Customer();
            customer.Id = 1;
            var resultObj = mockData.Setup(m => m.DeleteCustomer(customer.Id)).Returns(true);
            var response = _customerController.Delete(customer.Id);
            Assert.True(response);
        }
        [Fact]
        public void TestNegative_DeleteCustomer()
        {
            var customer = new Customer();
            customer.Id = 1;
            var resultObj = mockData.Setup(m => m.DeleteCustomer(customer.Id)).Returns(false);
            var response = _customerController.Delete(customer.Id);
            Assert.False(response);
        }

        private static Customer AddCustomer()
        {
            var newUser = new Customer();
            newUser.Id = 1;
            newUser.Customer_First_Name = "nishu";
            newUser.Customer_Last_Name = "patel";
            newUser.Customer_Phone_Number = "9685741210";
            return newUser;
        }
        private static IList<Customer> GetCustomer()
        {
            IList<Customer> customer = new List<Customer>()
            {
                new Customer() { Id = 1, Customer_First_Name = "Nishu", Customer_Last_Name = "Patel", Customer_Phone_Number = "9974297367" },
                new Customer() { Id = 2, Customer_First_Name = "Happy", Customer_Last_Name = "Patel", Customer_Phone_Number = "8574961230" }
            };
            return customer;
        }


    }
}
