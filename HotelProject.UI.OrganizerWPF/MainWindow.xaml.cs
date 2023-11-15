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


namespace HotelProject.UI.OrganizerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OrganizerManager _organizerManager;
        public MainWindow()
        {   
            InitializeComponent();
            _organizerManager = new OrganizerManager(RepositoryFactory.OrganizerRepository);
            //set all the organizers in the comboboxlist and only use the name
            DataContext = new { Organizers = _organizerManager.GetOrganizers() };

        }
        private void OrganizerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrganizer = (Organizer)OrganizerComboBox.SelectedItem;

            SelectedOrganizerTextBlock.Text = "Selected Organizer: " + (selectedOrganizer?.Name ?? "");

            WelcomeTextBlock.Text = "Welcome " + (selectedOrganizer?.Name ?? "") + "!";

            if (selectedOrganizer != null)
            {
                button1.IsEnabled = true;
                button2.IsEnabled = true;
            }
        }


        private void ViewActivities_Click(object sender, RoutedEventArgs e)
        {
            ViewActivitiesWindow viewActivitiesWindow = new ViewActivitiesWindow();
            viewActivitiesWindow.Show();
        }

        private void AddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            AddNewActivityWindow addNewActivityWindow = new AddNewActivityWindow();
            addNewActivityWindow.Show();
        }
    }
}
