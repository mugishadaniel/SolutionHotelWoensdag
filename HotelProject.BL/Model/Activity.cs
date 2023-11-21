using HotelProject.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Model
{
    public class Activity
    {
        public Activity(int id,string name, string description, DateTime date, int duration, int availablePlaces, decimal priceAdult, decimal priceChild,decimal discount, string location)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Duration = duration;
            AvailablePlaces = availablePlaces;
            PriceAdult = priceAdult;
            PriceChild = priceChild;
            Discount = discount;
            Location = location;
        }

        public int Id { get { return _id; } set { if (value < 0) throw new ActivityException("invalid id"); _id = value; } }
        private int _id;
        public string Name { get { return _name; } set { if (string.IsNullOrWhiteSpace(value)) throw new ActivityException("name is empty"); _name = value; } }
        private string _name;
        public string Description { get { return _description; } set { if (string.IsNullOrWhiteSpace(value)) throw new ActivityException("description is empty"); _description = value; } }
        private string _description;
        public DateTime Date { get { return _date; } set { if (value == null) throw new ActivityException("date is null"); _date = value; } }
        private DateTime _date;
        public int Duration { get { return _duration; } set { if (value <= 0) throw new ActivityException("invalid duration"); _duration = value; } }
        private int _duration;
        public int AvailablePlaces { get { return _availablePlaces; } set { if (value < 0) throw new ActivityException("invalid availableplaces"); _availablePlaces = value; } }
        private int _availablePlaces;
        public decimal PriceAdult { get { return _priceAdult; } set { if (value <= 0) throw new ActivityException("invalid priceadult"); _priceAdult = value; } }
        private decimal _priceAdult;
        public decimal PriceChild { get { return _priceChild; } set { if (value <= 0) throw new ActivityException("invalid pricechild"); _priceChild = value; } }
        private decimal _priceChild;
        public string Location { get { return _location; } set { if (string.IsNullOrWhiteSpace(value)) throw new ActivityException("location is empty"); _location = value; } }
        private string _location;
        public decimal? Discount { get { return _discount; } set { if (value < 0 || value > 100) throw new ActivityException("invalid discount"); _discount = value; } }
        private decimal? _discount;


    }
}
