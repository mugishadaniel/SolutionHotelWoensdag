using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class AddressTests
    {
        [Fact]
        public void AddressTest()
        {
            string addressLine = "test,test,test,test";
            Address address = new Address(addressLine);
            Assert.Equal("test", address.Municipality);
            Assert.Equal("test", address.ZipCode);
            Assert.Equal("test", address.HouseNumber);
            Assert.Equal("test", address.Street);
        }

        [Fact]
        public void Address_WithInvalidMunicipality_ThrowsAddressException()
        {
            Assert.Throws<AddressException>(() => new Address("","test","test","test"));
        }
        [Fact]
        public void Address_WithInvalidZipCode_ThrowsAddressException()
        {
            Assert.Throws<AddressException>(() => new Address("test", "", "test", "test"));
        }
        [Fact]
        public void Address_WithInvalidHouseNumber_ThrowsAddressException()
        {
            Assert.Throws<AddressException>(() => new Address("test", "test", "", "test"));
        }
        [Fact]
        public void Address_WithInvalidStreet_ThrowsAddressException()
        {
            Assert.Throws<AddressException>(() => new Address("test", "test", "test", ""));
        }

    }
}
