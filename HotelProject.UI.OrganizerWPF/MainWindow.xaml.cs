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
        public MainWindow()
        {
            InitializeComponent();
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
