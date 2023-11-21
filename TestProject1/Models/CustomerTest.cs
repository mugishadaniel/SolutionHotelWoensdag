using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;

namespace TestProjectHotel.Models
{
    public class CustomerTest
    {
        [Fact]
        public void Customer_ValidWithConstructor()
        {
            // Arrange & Act
            var ci = new ContactInfo("email@", "phone",new Address("test,test,test,test"));
            var customer = new Customer("name", 1, ci);

            // Assert
            Assert.Equal("name", customer.Name);
            Assert.Equal(1, customer.Id);
            Assert.Equal(ci, customer.ContactInfo);
        }

        [Fact]
        public void Customer_InvalidName()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerException>(() => new Customer("", 1, new ContactInfo("email@", "phone", new Address("test,test,test,test"))));
        }

        [Fact]
        public void Customer_InvalidId()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerException>(() => new Customer("name", 0, new ContactInfo("email@", "phone", new Address("test,test,test,test"))));
        }

        [Fact]
        public void Customer_InvalidContactInfo()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerException>(() => new Customer("name", 1, null));
        }

        [Fact]
        public void Customer_InvalidMembersList()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerException>(() => new Customer("name", 1, new ContactInfo("email@", "phone", new Address("test,test,test,test"))) { Members = null });
        }

        [Fact]
        public void Customer_AddMemberInvalid()
        {
            // Arrange
            var d = new DateOnly(2000, 1, 1);
            var ci = new ContactInfo("email@", "phone", new Address("test,test,test,test"));
            var customer = new Customer("name", 1, ci);
            var member = new Member("name", d);
            customer.AddMember(member);

            // Act & Assert
            Assert.Throws<CustomerException>(() => customer.AddMember(member));
        }

        [Fact]
        public void Customer_RemoveMemberInvalid()
        {
            // Arrange
            var d = new DateOnly(2000, 1, 1);
            var ci = new ContactInfo("email@", "phone", new Address("test,test,test,test"));
            var customer = new Customer("name", 1, ci);
            var member = new Member("name", d);

            // Act & Assert
            Assert.Throws<CustomerException>(() => customer.RemoveMember(member));
        }
    }
}