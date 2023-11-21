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
        private List<Registration> registrations;
        public MainWindow()
        {
            InitializeComponent();
            registrationManager = new RegistrationManager(RepositoryFactory.RegistrationRepository);
            customerManager = new CustomerManager(RepositoryFactory.CustomerRepository);
            activityManager = new ActivityManager(RepositoryFactory.ActivityRepository);
            memberManager = new MemberManager(RepositoryFactory.MemberRepository);
            CustomerComboBox.ItemsSource = customerManager.GetCustomers(null);
            ActivitiesComboBox.ItemsSource = activityManager.GetActivities(null);
            registrations = registrationManager.GetAllRegistrations();
            customer = new Customer();
            customer.Members = new List<Member>();

        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            //check if all fields are filled
            if (CustomerComboBox.SelectedItem == null || ActivitiesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            // check first if the activity is before today
            if (activity.Date < DateTime.Now)
            {
                MessageBox.Show("Please choose an activity that is not in the past");
                return;
            }

            //check if there are enough seats for that date
            if (activity.AvailablePlaces < registration.NumberOfAdults + registration.NumberOfChildren)
            {
                MessageBox.Show("There are not enough seats for this activity");
                return;
            }

            // check if this activity is already registered by someone else
            foreach (Registration reg in registrations)
            {
                if (reg.Activity.Id == activity.Id)
                {
                    MessageBox.Show("This activity is already registered by someone else");
                    return;
                }
            }


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
            MembersListBox.IsEnabled = true;
            MembersListBox.SelectedItems.Clear();
            activity = ActivitiesComboBox.SelectedItem as Activity;
            DateTextBlock.Text = activity.Date.ToString();
            LocationTextBlock.Text = activity.Location;
            AvailableSeatsTextBlock.Text = activity.AvailablePlaces.ToString();
            customer.Members = new List<Member>();
            registration = new Registration(customer, activity);

            if (activity.Discount == null || activity.Discount == 0)
            {
                SubtotalAdultsTextBlock.Text = registration.costAdult.ToString() + $"       {registration.NumberOfAdults} adult(s)";
                SubtotalChildrenTextBlock.Text = registration.costChild.ToString() + $"       {registration.NumberOfChildren} children";
                DiscountTextBlock.Text = " ";
                TotalCostTextBlock.Text = registration.Price.ToString();
            }
            else
            {
                SubtotalAdultsTextBlock.Text = registration.costAdult.ToString() + $" ({activity.PriceAdult * registration.NumberOfAdults})       {registration.NumberOfAdults} adult(s)";
                SubtotalChildrenTextBlock.Text = registration.costChild.ToString() + $" ({activity.PriceChild * registration.NumberOfChildren})      {registration.NumberOfChildren} children";
                DiscountTextBlock.Text = $"Discount: {activity.Discount}%";
                TotalCostTextBlock.Text = registration.Price.ToString();
            }

        }

        private void MembersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer.Members = new List<Member>();

            foreach (Member member in MembersListBox.SelectedItems)
            {
               customer.Members.Add(member);
            }

            registration = new Registration(customer, activity);
            if (activity.Discount == null || activity.Discount == 0)
            {
                SubtotalAdultsTextBlock.Text = registration.costAdult.ToString() + $"       {registration.NumberOfAdults} adults";
                SubtotalChildrenTextBlock.Text = registration.costChild.ToString() + $"       {registration.NumberOfChildren} children";
                DiscountTextBlock.Text = " ";
                TotalCostTextBlock.Text = registration.Price.ToString();
            }
            else
            {
                SubtotalAdultsTextBlock.Text = $"{registration.costAdult.ToString()} ({activity.PriceAdult * registration.NumberOfAdults} per adult)       {registration.NumberOfAdults} adults";
                SubtotalChildrenTextBlock.Text = $"{registration.costChild.ToString()} ({activity.PriceChild * registration.NumberOfChildren})       {registration.NumberOfChildren} children";
                DiscountTextBlock.Text = $"Discount: {activity.Discount}%";
                TotalCostTextBlock.Text = registration.Price.ToString();
            }


        }
    }
}
