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

            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
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
