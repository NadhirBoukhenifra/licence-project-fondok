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
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        private int errorCount;
        public ReservationWindow()
        {


            InitializeComponent();
            DataContext = this;


            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));
            var context = new DatabaseContext();


            string[] ReservationStatusSource = new string[] { "InComplete", "Complete" };

            ReservationStatusField.ItemsSource = ReservationStatusSource;

            var ReservedBySource = (from s in context.Employees select s.EmployeeUserName).ToArray();

            ReservedByField.ItemsSource = ReservedBySource;

            //var clnt = (from s in context.Clients select (s.ClientID)).ToList();
            //var rsrv = (from s in context.Reservations select (s.ReservedFor)).ToList();
            //var ReservedForSource = clnt.Except(rsrv).ToArray();

            var ReservedForSource = (from s in context.Clients select s.ClientID).ToArray();

            ReservedForField.ItemsSource = ReservedForSource;

            var RoomNumberSource = (from s in context.Rooms
                                    where (s.RoomStatus != "Reserved" && s.RoomStatus != "Out Service")
                                    select s.RoomID
                                    ).ToArray();

            RoomNumberField.ItemsSource = RoomNumberSource;

            var ReservationFormSource = (from s in context.Forms select s.FormTitle).ToArray();

            ReservationFormField.ItemsSource = ReservationFormSource;
            ReservedForField.SelectedIndex = -1;
            ReservationFormField.SelectedIndex = -1;
            RoomNumberField.SelectedIndex = -1;
        }
        private void AddReservationClick(object sender, RoutedEventArgs e)
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

            AddReservationButton.IsEnabled = errorCount == 0;
        }


        public void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckInDateField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDown(object sender, TouchEventArgs e)
        {
            CheckInDateField.IsDropDownOpen = true;
        }

        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckInDateField.IsDropDownOpen = false;
        }



        public void TextBoxPreviewMouseDownTwo(object sender, MouseButtonEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDownTwo(object sender, TouchEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = true;
        }

        private void DatePickerSelectedDateChangedTwo(object sender, SelectionChangedEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = false;
        }

        private void ReservationFormField_DropDownClosed(object sender, EventArgs e)
        {


            var context = new DatabaseContext();

            var Rm = (from s in context.Rooms where(s.RoomNumber.ToString() == 
                      RoomNumberField.SelectedValue.ToString())
                      select s.RoomPrice).ToArray();
            MessageBox.Show("Window" + Rm[0].ToString());
            var Fr = (from s in context.Forms
                      where (s.FormTitle.ToString() ==
ReservationFormField.SelectedValue.ToString())
                      select s.FormPrice).ToArray<double>();
            MessageBox.Show("Window" + Fr[0].ToString());

            DateTime a = CheckOutDateField.SelectedDate.Value;
            DateTime b = CheckInDateField.SelectedDate.Value;
            TimeSpan ts = a - b;
            double days = Math.Abs(ts.Days)+1;

           

            TotalPriceField.Text = (Rm[0]  + Fr[0]) * days + " DZD";
            MessageBox.Show("Window" + TotalPriceField.Text.ToString());
        }
    }
}
