using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

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
            

        }
        

        private void Window_Closing(object sender, EventArgs e)
        {
            MessageBox.Show("Good Bye From Mainwindow :)!");
            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();

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
