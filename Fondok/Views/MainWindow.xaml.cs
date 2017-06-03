using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReservationButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            dateText.Text = DateTime.Now.ToLongDateString();
        }

        private void ReservationClick(object sender, RoutedEventArgs e)
        {
            ReservationButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ReservationButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush"); 
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush"); 
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush"); 
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush"); 
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");

            ReservationIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void RoomClick(object sender, RoutedEventArgs e)
        {
            RoomButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            RoomButton.Foreground = new SolidColorBrush(Colors.White);
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            RoomIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            ClientButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ClientButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void ServiceClick(object sender, RoutedEventArgs e)
        {
            ServiceButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ServiceButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void InvoiceClick(object sender, RoutedEventArgs e)
        {
            InvoiceButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            InvoiceButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");

            InvoiceIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void ReportClick(object sender, RoutedEventArgs e)
        {
            ReportButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ReportButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            EmployeeButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");

            ReportIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            EmployeeButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            EmployeeIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
        }

        private void EmployeeClick(object sender, RoutedEventArgs e)
        {
            EmployeeButton.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            EmployeeButton.Foreground = new SolidColorBrush(Colors.White);
            RoomButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReservationButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ClientButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ServiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            InvoiceButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            ReportButton.Foreground = (Brush)FindResource("PrimaryHueMidBrush");

            EmployeeIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            ReservationButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            RoomButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ClientButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ServiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            InvoiceButton.Style = (Style)FindResource("MaterialDesignFlatButton");
            ReportButton.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoiceIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
        }




        private void WindowClosing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit? Mainwindow", "Exit from Fondok", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //MessageBox.Show("Good Bye :) Mainwindow", "Fondok");


                    //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();

                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
