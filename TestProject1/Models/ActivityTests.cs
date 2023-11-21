using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class ActivityTests
    {
        [Fact]
        public void Activty_ValidWithConstructors()
        {
            //Arrange & Act 
            var a = new Activity(1,"activity","description",DateTime.Now,50,5,1,1,20,"location");

           // Assert
           Assert.Equal(1, a.Id);
            Assert.Equal("activity", a.Name);
            Assert.Equal("description", a.Description);
            Assert.Equal(50, a.Duration);
            Assert.Equal(5, a.AvailablePlaces);
            Assert.Equal(1, a.PriceAdult);
            Assert.Equal(1, a.PriceChild);
            Assert.Equal(20, a.Discount);
            Assert.Equal("location", a.Location);
        }
        [Fact]
        public void Activty_InvalidId()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(-1, "activity", "description", DateTime.Now, 50, 5, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidName()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "", "description", DateTime.Now, 50, 5, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidDescription()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "", DateTime.Now, 50, 5, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidDate()
        {
            //Arrange & Act & Assert
            DateTime dateTime = new DateTime();
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description",dateTime , 50, 5, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidDuration()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, -1, 5, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidAvailablePlaces()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, 50, -1, 0, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidPriceAdult()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, 50, 5, -1, 0, 20, ""));
        }
        [Fact]
        public void Activty_InvalidPriceChild()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, 50, 5, 0, -1, 20, ""));
        }
        [Fact]
        public void Activty_InvalidDiscount()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, 50, 5, 0, 0, -1, ""));
        }
        [Fact]
        public void Activty_InvalidLocation()
        {
            //Arrange & Act & Assert
            Assert.Throws<ActivityException>(() => new Activity(1, "activity", "description", DateTime.Now, 50, 5, 0, 0, 20, null));
        }
    }
}
