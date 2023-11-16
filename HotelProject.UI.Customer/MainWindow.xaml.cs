using HotelProject.BL.Managers;
using HotelProject.BL.Model;
using HotelProject.DL.Repositories;
using HotelProject.UI.CustomerWPF.Model;
using HotelProject.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelProject.UI.CustomerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerManager customerManager;
        private ObservableCollection<CustomerUI> customersUIs = new ObservableCollection<CustomerUI>();
        public MainWindow()
        {
            InitializeComponent();
            customerManager = new CustomerManager(RepositoryFactory.CustomerRepository);
            GetDatabaseInfo();
            Refresh();


        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            customersUIs.Clear();
            foreach (Customer c in customerManager.GetCustomers(SearchTextBox.Text))
            {
                List<MemberUI> membersUI = new List<MemberUI>();
                foreach (Member m in c.GetMembers())
                {
                    membersUI.Add(new MemberUI(m.Name, m.BirthDay));
                }
                customersUIs.Add(new CustomerUI(c.Id, c.Name, c.ContactInfo.Email, c.ContactInfo.Phone, c.ContactInfo.Address.ToString(), membersUI));
            }
        }

        private void MenuItemAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow w = new CustomerWindow(false, null);
            if (w.ShowDialog() == true)
                customersUIs.Add(w.customerUI);
            Refresh();
        }

        private void MenuItemDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            //delete the selected customer
            if (CustomerDataGrid.SelectedItem == null) MessageBox.Show("Customer not selected", "Delete");
            else
            {
                customerManager.DeleteCustomer(((CustomerUI)CustomerDataGrid.SelectedItem).Id);
                customersUIs.Remove((CustomerUI)CustomerDataGrid.SelectedItem);
                Refresh();
            }
        }

        private void MenuItemUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem == null) MessageBox.Show("Customer not selected", "Update");
            else
            {
                CustomerWindow w = new CustomerWindow(true, (CustomerUI)CustomerDataGrid.SelectedItem);
                w.ShowDialog();
            }
            Refresh();
        }

        public void Refresh()
        {
         
            CustomerDataGrid.ItemsSource = customersUIs;
            CustomerDataGrid.Loaded += (sender, e) =>
            {
                CustomerDataGrid.Columns[5].Visibility = Visibility.Hidden;
                CustomerDataGrid.Columns[7].Visibility = Visibility.Hidden;
                CustomerDataGrid.Columns[8].Visibility = Visibility.Hidden;
                CustomerDataGrid.Columns[9].Visibility = Visibility.Hidden;
                CustomerDataGrid.Columns[10].Visibility = Visibility.Hidden;
            };
        }

        public void GetDatabaseInfo()
        {
            foreach (Customer c in customerManager.GetCustomers(null))
            {
                List<MemberUI> membersUI = new List<MemberUI>();
                foreach (Member m in c.GetMembers())
                {
                    membersUI.Add(new MemberUI(m.Name, m.BirthDay));
                }
                customersUIs.Add(new CustomerUI(c.Id, c.Name, c.ContactInfo.Email, c.ContactInfo.Phone, c.ContactInfo.Address.ToString(), membersUI));
            }
        }


    }
}
