using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class ContactInfoTests
    {
        [Fact]
        public void ContactInfo_ValidWithConstructor()
        {
            // Arrange & Act
            var ci = new ContactInfo("test@", "123456789", new Address("test", "test", "test", "test"));
            
            // Assert
            Assert.Equal("test@", ci.Email);
            Assert.Equal("123456789", ci.Phone);
            Assert.Equal("test", ci.Address.Municipality);
            Assert.Equal("test", ci.Address.ZipCode);
            Assert.Equal("test", ci.Address.Street);
            Assert.Equal("test", ci.Address.HouseNumber);

        }
        [Fact]
        public void ContactInfo_InvalidEmail()
        {
            // Arrange & Act & Assert
            Assert.Throws<ContactInfoException>(() => new ContactInfo("test", "123456789", new Address("test", "test", "test", "test")));
        }
        [Fact]
        public void ContactInfo_InvalidPhone()
        {
            // Arrange & Act & Assert
            Assert.Throws<ContactInfoException>(() => new ContactInfo("test@", "", new Address("test", "test", "test", "test")));
        }
        [Fact]
        public void ContactInfo_InvalidAddress()
        {
            // Arrange & Act & Assert
            Assert.Throws<ContactInfoException>(() => new ContactInfo("test@", "123456789", null));
        }
    }
}
