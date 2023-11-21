using HotelProject.BL.Exceptions;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectHotel.Models
{
    public class MemberTests
    {
        [Fact]
        public void Member_ValidWithConstructor()
        {
            // Arrange
            string name = "Ivan";
            DateOnly birthDay = new DateOnly(1990, 1, 1);
            // Act
            Member member = new Member(name, birthDay);
            // Assert
            Assert.Equal(name, member.Name);
            Assert.Equal(birthDay, member.BirthDay);
        }

        [Fact]
        public void Member_InvalidNameWithConstructor()
        {
            // Arrange
            string name = "";
            DateOnly birthDay = new DateOnly(1990, 1, 1);
            // Act
            // Assert
            Assert.Throws<MemberException>(() => new Member(name, birthDay));
        }

        [Fact]
        public void Member_InvalidBirthDayWithConstructor()
        {
            // Arrange
            string name = "Ivan";
            DateTime dateTime = DateTime.Now.AddDays(1);
            DateOnly birthDay = DateOnly.FromDateTime(dateTime);
            // Act
            // Assert
            Assert.Throws<MemberException>(() => new Member(name, birthDay));
        }
    }
}
