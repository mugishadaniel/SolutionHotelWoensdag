using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.UI.CustomerWPF.Model
{
    public class CustomerUI : INotifyPropertyChanged
    {
        public CustomerUI(int id, string name, string email, string phone, string address,List<MemberUI> members)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this._members = members;
            CleanAdressFormat();

        }

        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
        private string phone;
        public string Phone { get { return phone; } set { phone = value; OnPropertyChanged(); } }
        private string address;
        public string Address { get { return address; } set { address = value; OnPropertyChanged(); } }
        public List<MemberUI> _members { get; set; }
        public int Members { get { return _members.Count; } }

        public string Municipality { get; private set; }
        public string ZipCode { get; private set; }
        public string HouseNumber { get; private set; }
        public string Street { get; private set; }



        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        

        public void CleanAdressFormat()
        {
            if (Address.StartsWith("("))
            {
                string cleanedAdress = Address.Trim('(', ')', ']');
                string[] parts = cleanedAdress.Split(new char[] { '[', '-',}, StringSplitOptions.RemoveEmptyEntries);
                Municipality = parts[0].Trim();
                ZipCode = parts[1].Trim(']',' ');
                Street = parts[2].Trim();
                HouseNumber = parts[3].Trim();
            }
            else
            {
                string[] parts = Address.Split(new char[] { ',' });
                HouseNumber = parts[2];
                Street = parts[1];
                Municipality = parts[0];
                ZipCode = parts[3];
            }

        }

    }
}
