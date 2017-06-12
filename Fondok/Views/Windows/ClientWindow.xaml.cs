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
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        
        private int errorCount;
        public ClientWindow()
        {
           

            InitializeComponent();
            DataContext = this;
            ClientDateOfBirthField.DisplayDateStart = DateTime.Now.AddYears(-100);
            ClientDateOfBirthField.DisplayDateEnd = DateTime.Now.AddYears(-10);
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));

            string[] ClientGenderSource = new string[] { "Male", "Female", "Other" };

            ClientGenderField.ItemsSource = ClientGenderSource;

            string[] ClientIDTypeSource = new string[] { "ID card", "Passport", "Driver License", "Birth Document" };

            ClientIDTypeField.ItemsSource = ClientIDTypeSource;

            //DataContext = this;
            var context = new DatabaseContext();

            var ClientParentSource = (from s in context.Clients where s.ClientParent==null select s.ClientID).ToArray();

            ClientParentField.ItemsSource = ClientParentSource;

        }
        private void AddClientClick(object sender, RoutedEventArgs e)
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

            AddClientButton.IsEnabled = errorCount == 0;
        }


        public void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ClientDateOfBirthField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDown(object sender, TouchEventArgs e)
        {
            ClientDateOfBirthField.IsDropDownOpen = true;
           

        }

        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientDateOfBirthField.IsDropDownOpen = false;
        }
        
        private void ClientFirstNameField_PreviewKeyDown(object sender, KeyEventArgs e)
        {

           Verif.JustChar(sender,e); 

        }

        private void ClientLastNameField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Verif.JustChar(sender, e);
        }

        private void ClientIDNumberField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           Verif.JustNum(sender, e);
        }
        Commands.Verifications Verif = new Commands.Verifications();
    }
  
}



