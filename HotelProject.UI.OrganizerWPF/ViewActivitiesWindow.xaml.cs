using HotelProject.BL.Managers;
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

namespace HotelProject.UI.OrganizerWPF
{
    /// <summary>
    /// Interaction logic for ViewActivitiesWindow.xaml
    /// </summary>
    public partial class ViewActivitiesWindow : Window
    {
        private ActivityManager activityManager;
        public ViewActivitiesWindow()
        {
            InitializeComponent();
            activityManager = new ActivityManager(RepositoryFactory.ActivityRepository);
;           RefreshActivities();
        }

        private void SearchButton_Click(object sender, object e)
        {
            //show activities that match the search
            ActivitiesDataGrid.ItemsSource = activityManager.GetActivities(SearchTextBox.Text);
        }

        private void RefreshActivities()
        {
            //show all activities
            ActivitiesDataGrid.ItemsSource = activityManager.GetActivities(null);
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshActivities();
        }
    }
}
