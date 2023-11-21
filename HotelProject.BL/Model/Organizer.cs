using HotelProject.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Model
{
    public class Organizer
    {
        private string _name;
        public string Name { get { return _name; } set { if (string.IsNullOrWhiteSpace(value)) throw new OrganizerException("name is empty"); _name = value; } }
        private int _id;
        public int Id { get { return _id; } set { if (value <= 0) throw new OrganizerException("invalid id"); _id = value; } }
        private ContactInfo _contactInfo;

        public Organizer(int id,string name, ContactInfo contactInfo)
        {
            Name = name;
            ContactInfo = contactInfo;
            Id = id;
        }

        public ContactInfo ContactInfo { get { return _contactInfo; } set { if (value == null) throw new OrganizerException("contactinfo null"); _contactInfo = value; } }

    }
}
