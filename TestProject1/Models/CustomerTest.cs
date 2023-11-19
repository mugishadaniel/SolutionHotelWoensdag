using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;

namespace TestProjectHotel.Model
{
    public class CustomerTest
    {
        [Fact]
        public void InvalidEmailCustomer()
        {

            string email = "test";
            string phone = "123456789";
            Address address = new Address("test", "test", "test", "test");

            Assert.Throws<ContactInfoException>(() => new ContactInfo(email, phone, address));
        }
        [Fact]
        public void InvalidPhoneCustomer()
        {
            string email = "test@";
            string phone = "";
            Address address = new Address("test", "test", "test", "test");
            Assert.Throws<ContactInfoException>(() => new ContactInfo(email, phone, address));
        }

        [Fact]
        public void InvalidAddressCustomer()
        {
            string email = "test@";
            string phone = "123456789";
            Address address = null;
            Assert.Throws<ContactInfoException>(() => new ContactInfo(email, phone, address));
        }

        [Fact]
        public void InvalidNameCustomer()
        {
            string name = "";
            int id = 1;
            ContactInfo contactInfo = new ContactInfo("test@", "123456789", new Address("test", "test", "test", "test"));
            Assert.Throws<CustomerException>(() => new Customer(name, contactInfo));
        }
    }
}