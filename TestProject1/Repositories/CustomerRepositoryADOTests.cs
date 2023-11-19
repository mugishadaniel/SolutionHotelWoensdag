using HotelProject.BL.Interfaces;
using HotelProject.BL.Managers;
using HotelProject.BL.Model;
using HotelProject.DL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Repositories
{
    public class CustomerRepositoryADOTests
    {
        public Mock<ICustomerRepository> _customerRepositoryMock;
        public CustomerManager _customerManager;

        public CustomerRepositoryADOTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerManager = new CustomerManager(_customerRepositoryMock.Object);
        }
        [Fact]
        public void GetCustomers_WithFilter_ReturnsCustomers()
        {
            //Arrange
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("test", 1, new ContactInfo("test@", "test", new Address("test", "test", "test", "test"))));
            customers.Add(new Customer("test2", 2, new ContactInfo("test2@", "test2", new Address("test2", "test2", "test2", "test2"))));
            customers.Add(new Customer("test3", 3, new ContactInfo("test3@", "test3", new Address("test3", "test3", "test3", "test3"))));
            string filter = "test";
            _customerRepositoryMock.Setup(x => x.GetCustomers(filter)).Returns(customers);

            //Act
            List<Customer> result = _customerManager.GetCustomers(filter);


            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

        }
    }
}
