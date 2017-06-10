using Fondok.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Fondok.Views.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();

            string[] EmployeeJobList = new string[] { "Admin", "Receptionist"};

            EmployeeJobField.ItemsSource = EmployeeJobList;

        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (EmployeeUserNameField.Text == "")
            {
                MessageBox.Show("Edit Content");
            }

           
            DialogResult = true;

        }

        public void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDown(object sender, TouchEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = true;
        }

        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = false;
          //  EmployeeDateOfBirthField.SelectedDate = EmployeeDateOfBirthField.SelectedDate.Value.Date;
        }

    }

}
