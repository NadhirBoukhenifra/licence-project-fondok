using Fondok.Context;
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

using Fondok.Models;

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




        private void LoginClick(object sender, RoutedEventArgs e)


        {

            using (var context = new DatabaseContext())
            {
                var EmployeesList = (from s in context.Employees where s.EmployeeUserName == this.userNameField.Text select s).ToList<Employee>();
                var EmployeeGrade =(from s in context.Employees where s.EmployeeUserName == this.userNameField.Text && s.EmployeePassWord==this.userPasswordField.Password select s).ToList<Employee>();
                
                
                //MainWindow.grade = EmployeeGrade[0].EmployeeJob; Amine


                if (EmployeesList[0].EmployeeUserName == this.userNameField.Text && EmployeesList[0].EmployeePassWord == this.userPasswordField.Password)
                {
                    MessageBox.Show(" Welcome: " + EmployeesList[0].EmployeeJob + ", " + EmployeesList[0].EmployeeFirstName + " " + EmployeesList[0].EmployeeLastName);
                    Application.Current.MainWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error");
                }

                //MessageBox.Show(EmployeesList[0].EmployeeUserName + EmployeesList[0].EmployeeEMail + EmployeesList.Count());



            }




        }

        private void WindowClosing(object sender, CancelEventArgs e)
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
