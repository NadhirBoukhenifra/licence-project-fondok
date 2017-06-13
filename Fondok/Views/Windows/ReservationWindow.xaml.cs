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
           

            string[] TypePaymentSource = new string[] { "Cash Money", "Bank Check", "Credit Card", "Western Union" };

            TypePaymentField.ItemsSource = TypePaymentSource;

            string[] ReservationStatusSource = new string[] { "Incomplete", "Complete" };

            ReservationStatusField.ItemsSource = ReservationStatusSource;

            var ReservedBySource = (from s in context.Employees select s.EmployeeUserName).ToArray();

            ReservedByField.ItemsSource = ReservedBySource;

            //var clnt = (from s in context.Clients select (s.ClientID)).ToList();
            //var rsrv = (from s in context.Reservations select (s.ReservedFor)).ToList();
            //var ReservedForSource = clnt.Except(rsrv).ToArray();



            //Fixed By Med Amin (Showing ParentClients Firstname and Lastname and ID Number to avoid name there conflits  )
            var ReservedForSource = (from s in context.Clients where s.ClientParent==null select s.ClientFirstName+" "+s.ClientLastName+ " | ID N°" + s.ClientIDNumber).ToArray();
          

            ReservedForField.ItemsSource = ReservedForSource;

            var RoomNumberSource = (from s in context.Rooms
                                    where (s.RoomStatus == "Not Reserved")
                                    select s.RoomID
                                    ).ToArray();

            RoomNumberField.ItemsSource = RoomNumberSource;

            var ReservationFormSource = (from s in context.Forms select s.FormTitle).ToArray();

            ReservationFormField.ItemsSource = ReservationFormSource;
            ReservedForField.SelectedIndex = -1;
            ReservationFormField.SelectedIndex = -1;
            RoomNumberField.SelectedIndex = -1;
            //Amin Mod Check out can't be before Check in
            CheckInDateField.DisplayDateStart = DateTime.Now;
            CheckInDateField.DisplayDateEnd = DateTime.Now.AddDays(90);
            CheckInDateField.SelectedDate = DateTime.Now;
            CheckOutDateField.SelectedDate = ((DateTime)CheckInDateField.SelectedDate).AddDays(1);
            CheckOutDateField.DisplayDateStart = ((DateTime)CheckInDateField.SelectedDate).AddDays(2);
            CheckOutDateField.DisplayDateEnd = ((DateTime)CheckOutDateField.DisplayDateStart).AddDays(100);
          
            {

            }
        }
        public void all_feilds ()
        {
            if (ReservationStatusField.SelectedIndex != -1 && ReservedByField.SelectedIndex != -1 
                && ReservedForField.SelectedIndex != -1 && RoomNumberField.SelectedIndex != -1 
                && ReservationFormField.SelectedIndex != -1 && TypePaymentField.SelectedIndex != -1)
            {
                DialogResult = true;
               

            }else
            {
                MessageBox.Show("Please fill all fields", "Fields required" ,MessageBoxButton.OK,MessageBoxImage.Warning );


            }
        }
        private void AddReservationClick(object sender, RoutedEventArgs e)
        {


            all_feilds();
            

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
        //IF CheckIn Date Changes  CheckOut Date will Change if it's been earlier (In DatePicker)
        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckInDateField.IsDropDownOpen = false;
            if(CheckOutDateField.SelectedDate< CheckInDateField.SelectedDate) {
                CheckOutDateField.SelectedDate = ((DateTime)CheckInDateField.SelectedDate).AddDays(1);
            }
            CheckOutDateField.DisplayDateStart = ((DateTime)CheckInDateField.SelectedDate).AddDays(1);
            CheckOutDateField.DisplayDateEnd = ((DateTime)CheckOutDateField.DisplayDateStart).AddDays(100);
            Price();
        }



        public void TextBoxPreviewMouseDownTwo(object sender, MouseButtonEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDownTwo(object sender, TouchEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = true;
          
        }
        //++-------------PRICE----CODE--------SIMON-----------------++
        private void DatePickerSelectedDateChangedTwo(object sender, SelectionChangedEventArgs e)
        {
            CheckOutDateField.IsDropDownOpen = false;
            Price();
        }

        private void ReservationFormField_DropDownClosed(object sender, EventArgs e)
        {

            Price();
          

        }
      
        private void RoomNumberField_DropDownClosed(object sender, EventArgs e)
        {
            Price();
        }

        private void ReservationStatusField_DropDownClosed(object sender, EventArgs e)
        {
            Price();
        }

        private void TypePaymentField_DropDownClosed(object sender, EventArgs e)
        {
            Price();
        }

        private void ReservedByField_DropDownClosed(object sender, EventArgs e)
        {
            Price();
        }


        public void Price()
        {

            var context = new DatabaseContext();



            if (ReservationFormField.SelectedItem != null
                && RoomNumberField.SelectedItem != null
                && CheckOutDateField.SelectedDate != null
                && CheckInDateField.SelectedDate != null)
            {
                
                var Rm = (from s in context.Rooms
                          where (s.RoomID.ToString() ==
    RoomNumberField.SelectedValue.ToString())
                          select s.RoomPrice).ToArray();

                var Fr = (from s in context.Forms
                          where (s.FormTitle.ToString() ==
    ReservationFormField.SelectedValue.ToString())
                          select s.FormPrice).ToArray<double>();


                DateTime a = CheckOutDateField.SelectedDate.Value;
                DateTime b = CheckInDateField.SelectedDate.Value;
                TimeSpan ts = a - b;
                double days = Math.Abs(ts.Days) + 1;



                TotalPriceField.Text = (Rm[0] + Fr[0]) * days + " DA";
            }

        }
    }
}
