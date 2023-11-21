using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class OrganizerTests
    {
        [Fact]
        public void Organizer_ValidWithConstructor()
        {
            // Arrange & Act
            var o = new Organizer(1, "test", new ContactInfo("test@","test",new Address("test,test,test,test"))); 
            
            // Assert
            Assert.NotNull(o);
            Assert.Equal(1, o.Id);
            Assert.Equal("test", o.Name);
                    
        }
        [Fact]
        public void Organizer_InvalidId_ThrowsOrganizerException()
        {
            // Arrange & Act & Assert
            Assert.Throws<OrganizerException>(() => new Organizer(0, "test", new ContactInfo("test@", "test", new Address("test,test,test,test"))));
        }
        [Fact]
        public void Organizer_InvalidName_ThrowsOrganizerException()
        {
            // Arrange
            Assert.Throws<OrganizerException>(() => new Organizer(1, "", new ContactInfo("test@", "test", new Address("test,test,test,test"))));

        }
        [Fact]
        public void Organizer_InvalidContactInfo_ThrowsOrganizerException()
        {
            // Arrange
            Assert.Throws<OrganizerException>(() => new Organizer(1, "test", null));

        }
    }
}
