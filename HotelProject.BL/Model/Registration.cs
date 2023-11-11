using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Model
{
    public class Registration
    {
        public Registration(int id, Customer customer, Activity activity, decimal price, int numberOfAdults, int numberOfChildren)
        {
            _id = id;
            _customer = customer;
            _activity = activity;
            _price = price;
            _numberOfAdults = numberOfAdults;
            _numberOfChildren = numberOfChildren;
        }

        public int Id { get { return _id; } set { if (value <= 0) throw new RegistrationException("invalid id"); _id = value; } }
        private int _id;
        public Customer Customer { get { return _customer; } set { if (value == null) throw new RegistrationException("customer null"); _customer = value; } }
        private Customer _customer;
        public Activity Activity { get { return _activity; } set { if (value == null) throw new RegistrationException("activity null"); _activity = value; } }
        private Activity _activity;
        public decimal Price { get { return _price; } set { if (value <= 0) throw new RegistrationException("invalid price"); _price = value; } }
        private decimal _price;
        public int NumberOfAdults { get { return _numberOfAdults; } set { if (value <= 0) throw new RegistrationException("invalid numberofadults"); _numberOfAdults = value; } }
        private int _numberOfAdults;
        public int NumberOfChildren { get { return _numberOfChildren; } set { if (value < 0) throw new RegistrationException("invalid numberofchildren"); _numberOfChildren = value; } }
        private int _numberOfChildren;

    }
}
