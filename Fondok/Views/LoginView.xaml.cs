using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            /*
            SQLiteDatabase DB = new SQLiteDatabase();

            DataTable Login;

            String Query = "select * from USERS where USERNAME='" + this.userNameBox.Text + "' and PASSWORD='" + this.userPasswordBox.Password + "'";

            Login = DB.GetDataTable(Query);

            string Grade = "select GRADE from USERS where USERNAME='" + this.userNameBox.Text + "' ";
            string User = "select USERNAME from USERS where USERNAME='" + this.userNameBox.Text + "' ";
            string Pass = "select PASSWORD from USERS where PASSWORD='" + this.userPasswordBox.Password + "' ";

            string _Grade = DB.ExecuteScalar(Grade);
            string _UserName = DB.ExecuteScalar(User);
            string _Password = DB.ExecuteScalar(Pass);

            if (this.userNameBox.Text != "" || this.userPasswordBox.Password != "")
            {
                if (this.userNameBox.Text == _UserName || this.userPasswordBox.Password == _Password)
                {
                    foreach (DataRow r in Login.Rows)
                    {
                        MessageBox.Show(String.Format("Welcome {0} : {1}", _Grade, _UserName));
                        Application.Current.MainWindow.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Please Chek Your Auth Informations, Or Contact Your Developper!");

                }
            }
            else
            {
                MessageBox.Show("Please Fill The Required Fields! \n Username \n Password");

            }
            */

            //App.Current.MainWindow.Show();
            //MainWindow _MainWindow = new MainWindow();
            //Application.Current.MainWindow = _MainWindow;
            //this.Hide();
            Application.Current.MainWindow.Show();
            this.Hide();

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("Good Bye From LoginWindow :)!");
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit? LoginWindow", "Exit from Fondok", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Good Bye :) Login", "Fondok");

                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();

                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }

            

        }
    }
}
