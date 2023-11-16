using HotelProject.BL.Managers;
using HotelProject.BL.Model;
using HotelProject.UI.CustomerWPF.Model;
using HotelProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HotelProject.UI.CustomerWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerUI customerUI;
        private bool isUpdate;
        private CustomerManager customerManager;
        private MemberManager memberManager;
        public CustomerWindow(bool isUpdate,CustomerUI customerUI)
        {
            InitializeComponent();
            customerManager = new CustomerManager(RepositoryFactory.CustomerRepository);
            memberManager = new MemberManager(RepositoryFactory.MemberRepository);
            this.customerUI = customerUI;
            this.isUpdate = isUpdate;
            if(isUpdate == false) MemberDataGrid.ContextMenu.IsEnabled = false;
            if (customerUI != null )
            {
                MemberDataGrid.ItemsSource = customerUI._members;
                IdTextBox.Text = customerUI.Id.ToString();
                NameTextBox.Text = customerUI.Name;
                EmailTextBox.Text = customerUI.Email;
                PhoneTextBox.Text = customerUI.Phone;
                CityTextBox.Text = customerUI.Municipality;
                ZipTextBox.Text = customerUI.ZipCode;
                HouseNumberTextBox.Text = customerUI.HouseNumber;
                StreetTextBox.Text = customerUI.Street;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //give a message box if not all fields are filled in
            if (NameTextBox.Text == "" || EmailTextBox.Text == "" || PhoneTextBox.Text == "" || CityTextBox.Text == "" || ZipTextBox.Text == "" || HouseNumberTextBox.Text == "" || StreetTextBox.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            if (isUpdate)
            {
                customerUI.Name = NameTextBox.Text;
                customerUI.Email = EmailTextBox.Text;
                customerUI.Phone = PhoneTextBox.Text;
                customerUI.Address = CityTextBox.Text+", "+StreetTextBox.Text+", "+HouseNumberTextBox.Text+", "+ZipTextBox.Text;
                //TODO customermanager.Update()
                customerManager.UpdateCustomer(new Customer(customerUI.Name,customerUI.Id, new ContactInfo(customerUI.Email, customerUI.Phone, new Address(customerUI.Address))));
            }
            else
            {

                Customer c = new Customer(NameTextBox.Text, new ContactInfo(EmailTextBox.Text, PhoneTextBox.Text, new Address(CityTextBox.Text, ZipTextBox.Text, HouseNumberTextBox.Text, StreetTextBox.Text)));
                //write customer
                customerManager.AddCustomer(c);
                c.Id = 100;
                //TODO id from DB
                customerUI = new CustomerUI(c.Id, c.Name, c.ContactInfo.Email, c.ContactInfo.Phone, c.ContactInfo.Address.ToString(),null);
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            MemberWindow memberWindow = new MemberWindow(false,customerUI);
            if (memberWindow.ShowDialog() == true)
            {

                
            }
            //show the new member in the datagrid
            customerUI._members.Add(memberWindow.memberUI);
            Refresh();
        }

        private void DeleteMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (MemberDataGrid.SelectedItem != null)
            {
                memberManager.DeleteMember(new Member(((MemberUI)MemberDataGrid.SelectedItem).Name, ((MemberUI)MemberDataGrid.SelectedItem).BirthDay), customerUI.Id);
                customerUI._members.Remove((MemberUI)MemberDataGrid.SelectedItem);
                Refresh();
            }
        }

        private void UpdateMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (MemberDataGrid.SelectedItem != null)
            {
                MemberWindow memberWindow = new MemberWindow(true,customerUI);
                memberWindow.oldMember = (MemberUI)MemberDataGrid.SelectedItem;
                if (memberWindow.ShowDialog() == true)
                {

                }
                customerUI._members.Remove((MemberUI)MemberDataGrid.SelectedItem);
                customerUI._members.Add(memberWindow.memberUI);
                Refresh();
            }
        }

        public void Refresh()
        {
            MemberDataGrid.ItemsSource = null;
            MemberDataGrid.ItemsSource = customerUI._members;
        }
    }
}
