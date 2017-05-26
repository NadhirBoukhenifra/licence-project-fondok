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
            Rooms.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //dateText.Content = DateTime.Now.ToLongDateString();
            //string _string = String.Format("Welcome: {0}" , Globals.userNamePlus);
            //dateText.Text = _string;
        }

        private void Reservations_Click(object sender, RoutedEventArgs e)
        {
            Reservations.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ReservationsIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            Rooms.Style = (Style)FindResource("MaterialDesignFlatButton");
            Clients.Style = (Style)FindResource("MaterialDesignFlatButton");
            Services.Style = (Style)FindResource("MaterialDesignFlatButton");
            Invoices.Style = (Style)FindResource("MaterialDesignFlatButton");
            Reports.Style = (Style)FindResource("MaterialDesignFlatButton");

            RoomsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            Rooms.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            RoomsIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            Reservations.Style = (Style)FindResource("MaterialDesignFlatButton");
            Clients.Style = (Style)FindResource("MaterialDesignFlatButton");
            Services.Style = (Style)FindResource("MaterialDesignFlatButton");
            Invoices.Style = (Style)FindResource("MaterialDesignFlatButton");
            Reports.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Clients.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ClientsIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            Reservations.Style = (Style)FindResource("MaterialDesignFlatButton");
            Rooms.Style = (Style)FindResource("MaterialDesignFlatButton");
            Services.Style = (Style)FindResource("MaterialDesignFlatButton");
            Invoices.Style = (Style)FindResource("MaterialDesignFlatButton");
            Reports.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            Services.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ServicesIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;

            Reservations.Style = (Style)FindResource("MaterialDesignFlatButton");
            Rooms.Style = (Style)FindResource("MaterialDesignFlatButton");
            Clients.Style = (Style)FindResource("MaterialDesignFlatButton");
            Invoices.Style = (Style)FindResource("MaterialDesignFlatButton");
            Reports.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void Invoices_Click(object sender, RoutedEventArgs e)
        {
            Invoices.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            InvoicesIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            Reservations.Style = (Style)FindResource("MaterialDesignFlatButton");
            Rooms.Style = (Style)FindResource("MaterialDesignFlatButton");
            Clients.Style = (Style)FindResource("MaterialDesignFlatButton");
            Services.Style = (Style)FindResource("MaterialDesignFlatButton");
            Reports.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ReportsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;

        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            Reports.Style = (Style)FindResource("MaterialDesignRaisedAccentButton");
            ReportsIcon.Foreground = FindResource("SecondaryAccentBrush") as SolidColorBrush;


            Reservations.Style = (Style)FindResource("MaterialDesignFlatButton");
            Rooms.Style = (Style)FindResource("MaterialDesignFlatButton");
            Clients.Style = (Style)FindResource("MaterialDesignFlatButton");
            Services.Style = (Style)FindResource("MaterialDesignFlatButton");
            Invoices.Style = (Style)FindResource("MaterialDesignFlatButton");

            ReservationsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            RoomsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ClientsIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            ServicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
            InvoicesIcon.Foreground = FindResource("PrimaryHueMidBrush") as SolidColorBrush;
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView lg = new LoginView();
            lg.Show();
            Application.Current.MainWindow.Hide();
            //this.Close();
        }

       
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit? Mainwindow", "Exit from Fondok", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Good Bye :) Mainwindow", "Fondok");

                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();

                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }


            //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            //Application.Current.Shutdown();


        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Globals.isLogin)
            {
                LoginView _LoginView = new LoginView();
                _LoginView.Show();

                this.Hide();
            }
        }
    }
}
