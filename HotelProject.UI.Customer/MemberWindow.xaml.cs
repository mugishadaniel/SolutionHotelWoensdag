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
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        public MemberUI memberUI;
        private bool isUpdate;
        private MemberManager memberManager;
        public CustomerUI customerUI;
        public MemberUI oldMember;
        public MemberWindow(bool isUpdate, CustomerUI customerUI)
        {
            InitializeComponent();
            this.isUpdate = isUpdate;
            this.customerUI = customerUI;
            memberManager = new MemberManager(RepositoryFactory.MemberRepository);

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(isUpdate)
            {
                memberUI = new MemberUI(NameTextBox.Text, DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate ?? DateTime.Today));
                //TODO membermanager.Update()
                memberManager.UpdateMember(new Member(memberUI.Name, memberUI.BirthDay),customerUI.Id,oldMember.Name);
                MessageBox.Show("Member updated");
                Close();
            }
            else
            {
                memberUI = new MemberUI(NameTextBox.Text, DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate ?? DateTime.Today));
                //TODO membermanager.Add()
                memberUI.Name = NameTextBox.Text;
                memberUI.BirthDay = DateOnly.FromDateTime(BirthdayDatePicker.SelectedDate ?? DateTime.Today);
                memberManager.AddMember(new Member(memberUI.Name, memberUI.BirthDay), customerUI.Id);
                MessageBox.Show("Member added");
                Close();


            }
        }
    }
}
