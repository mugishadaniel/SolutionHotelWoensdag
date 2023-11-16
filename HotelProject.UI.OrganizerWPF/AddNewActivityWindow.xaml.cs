﻿using HotelProject.BL.Managers;
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
using System.Windows.Shapes;

namespace HotelProject.UI.OrganizerWPF
{
    /// <summary>
    /// Interaction logic for AddNewActivityWindow.xaml
    /// </summary>
    public partial class AddNewActivityWindow : Window
    {
        private ActivityManager activityManager;

        public AddNewActivityWindow()
        {
            InitializeComponent();
            activityManager = new ActivityManager(RepositoryFactory.ActivityRepository);
        }

        private void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            // Get values from the input fields
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;
            DateTime date = DatePicker.SelectedDate ?? DateTime.Now;
            int selectedHours = int.Parse(((ComboBoxItem)HoursComboBox.SelectedItem).Content.ToString());
            int selectedMinutes = int.Parse(((ComboBoxItem)MinutesComboBox.SelectedItem).Content.ToString());
            date = date.AddHours(selectedHours).AddMinutes(selectedMinutes);
            int duration = Convert.ToInt32(DurationTextBox.Text);
            int availablePlaces = Convert.ToInt32(AvailablePlacesTextBox.Text);
            decimal priceAdult = Convert.ToDecimal(PriceAdultTextBox.Text);
            decimal priceChild = Convert.ToDecimal(PriceChildTextBox.Text);
            decimal discount = Convert.ToDecimal(DiscountTextBox.Text);
            string location = LocationTextBox.Text;

            // Create the new Activity object
            Activity newActivity = new Activity(0, name, description, date, duration, availablePlaces, priceAdult, priceChild,discount, location);

            // Add your logic to save the new activity to the database or perform other actions
            activityManager.AddActivity(newActivity);

            MessageBox.Show("Activity added successfully!");

            // Optionally close the window after adding the activity
            Close();
        }
    }
}
