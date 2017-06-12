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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        private int errorCount;
        public InvoiceWindow()
        {


            InitializeComponent();
            DataContext = this;


            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));

            var context = new DatabaseContext();

            string[] InvoiceTypePaymentSource = new string[] { "Cash Money", "Bank Check", "Master Card", "Western Union" };

            InvoiceTypePaymentField.ItemsSource = InvoiceTypePaymentSource;

            //string[] InvoiceIDTypeSource = new string[] { "ID card", "Passport", "Driver License", "Birth Document" };

            //InvoiceIDTypeField.ItemsSource = InvoiceIDTypeSource;


            var ReservationIDSource = (from s in context.Reservations select s.ReservationID).ToArray();

            ReservationIDField.ItemsSource = ReservationIDSource;
            InvoiceTypePaymentField.SelectedIndex = -1;
            InvoiceDateTimeField.DisplayDateStart = DateTime.Now.AddYears(-2);
            InvoiceDateTimeField.DisplayDateEnd = DateTime.Now.AddYears(2);
            InvoiceTotalField.Text = "550";
        }
        private void AddInvoiceClick(object sender, RoutedEventArgs e)
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

            AddInvoiceButton.IsEnabled = errorCount == 0;
        }


        public void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InvoiceDateTimeField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDown(object sender, TouchEventArgs e)
        {
            InvoiceDateTimeField.IsDropDownOpen = true;
        }

        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            InvoiceDateTimeField.IsDropDownOpen = false;
        }

        private void InvoiceTotalField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Verif.JustNum(sender, e);
        }
        Commands.Verifications Verif = new Commands.Verifications();

    }
}
