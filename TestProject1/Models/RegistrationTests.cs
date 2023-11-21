using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class RegistrationTests
    {
        [Fact]
        public void Registration_WithConstructor_ShouldCreateRegistration()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@","phone",new Address("test","test","test","test"));
            Customer customer = new Customer("test",1,contactInfo);
            Activity activity = new Activity(1,"activity","description",DateTime.Now,50,10,10,5,0,"location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.NotNull(registration);
        }

        [Fact]
        public void Registration_InvalidId_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.Id = -1);
        }
        [Fact]
        public void Registration_InvalidCustomer_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.Customer = null);
        }
        [Fact]
        public void Registration_InvalidActivity_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.Activity = null);
        }
        [Fact]
        public void Registration_InvalidPrice_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.Price = -1);
        }
        [Fact]
        public void Registration_InvalidCostChild_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.costChild = -1);
        }
        [Fact]
        public void Registration_InvalidCostAdult_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.costAdult = -1);
        }
        [Fact]
        public void Registration_InvalidNumberOfAdults_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.NumberOfAdults = -1);
        }
        [Fact]
        public void Registration_InvalidNumberOfChildren_ShouldThrowException()
        {
            //Arrange
            ContactInfo contactInfo = new ContactInfo("email@", "phone", new Address("test", "test", "test", "test"));
            Customer customer = new Customer("test", 1, contactInfo);
            Activity activity = new Activity(1, "activity", "description", DateTime.Now, 50, 10, 10, 5, 0, "location");
            //Act
            Registration registration = new Registration(customer, activity);
            //Assert
            Assert.Throws<RegistrationException>(() => registration.NumberOfChildren = -1);
        }
    }
}
