using Fondok.Context;
using Fondok.ViewModels;
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

namespace Fondok.Views.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private int errorCount;
        public EmployeeWindow()
        {


            InitializeComponent();
            DataContext = this;


            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));

            string[] EmployeeJobSource = new string[] { "Admin", "Receptionist" };

            EmployeeJobField.ItemsSource = EmployeeJobSource;

        }
        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
            {

                throw new Exception("Unexpected event args");
            }
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        errorCount++;
                        break;
                    }
                case ValidationErrorEventAction.Removed:
                    {
                        errorCount--;
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }

            AddEmployeeButton.IsEnabled = errorCount == 0;
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
        }

        private void EmployeeFirstNameField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Vchar.JustChar(sender, e);
        }

        private void EmployeeLastNameField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Vchar.JustChar(sender, e);
        }
        Commands.Verifications Vchar = new Commands.Verifications();
    }
    
}
