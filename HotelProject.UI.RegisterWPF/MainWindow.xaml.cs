using HotelProject.BL.Managers;
using HotelProject.BL.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelProject.UI.RegisterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RegistrationManager registrationManager;       
        private CustomerManager customerManager;
        private ActivityManager activityManager;
        private MemberManager memberManager;
        private Registration registration;
        private Customer customer;
        private Activity activity;
        private List<Member> members;
        public MainWindow()
        {
            InitializeComponent();
            registrationManager = new RegistrationManager(RepositoryFactory.RegistrationRepository);
            customerManager = new CustomerManager(RepositoryFactory.CustomerRepository);
            activityManager = new ActivityManager(RepositoryFactory.ActivityRepository);
            memberManager = new MemberManager(RepositoryFactory.MemberRepository);
            CustomerComboBox.ItemsSource = customerManager.GetCustomers(null);
            ActivitiesComboBox.ItemsSource = activityManager.GetActivities(null);
            customer = new Customer();
            customer.Members = new List<Member>();

        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            registrationManager.AddRegistration(registration);
            MessageBox.Show("Registration completed successfully");
            Close();
        }

        private void CustomerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            members = new List<Member>();
            customer = CustomerComboBox.SelectedItem as Customer;
            if (customer != null)
            {
                members = memberManager.GetMembers(customer.Id);
                MembersListBox.ItemsSource = members;
            }


        }

        private void ActivitiesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            activity = ActivitiesComboBox.SelectedItem as Activity;
            DateTextBlock.Text = activity.Date.ToString();
            LocationTextBlock.Text = activity.Location;
            AvailableSeatsTextBlock.Text = activity.AvailablePlaces.ToString();
        }

        private void MembersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer.Members = new List<Member>();
            foreach (Member member in MembersListBox.SelectedItems)
            {
                if(customer.Members.Contains(member))
                {
                    customer.Members.Remove(member);
                }
                else
                {
                    customer.Members.Add(member);
                }   
            }
            registration = new Registration(customer, activity);
            SubtotalAdultsTextBlock.Text = registration.costAdult.ToString() + $"    {registration.NumberOfAdults} adults";
            SubtotalChildrenTextBlock.Text = registration.costChild.ToString() + $"    {registration.NumberOfChildren} children";
            TotalCostTextBlock.Text = registration.Price.ToString();
        }
    }
}
