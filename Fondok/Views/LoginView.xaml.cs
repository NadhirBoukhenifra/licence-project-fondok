using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

     


        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.isLogin = !Globals.isLogin;


            Application.Current.MainWindow.Show();

            this.Hide();
            
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();

        }
    }
}
