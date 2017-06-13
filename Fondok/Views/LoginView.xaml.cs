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
        //public static string grade="recep";
        public LoginView()
        {
            InitializeComponent();
        }


        int Att = 4;
        int x = 3;

        private void LoginClick(object sender, RoutedEventArgs e)


        {
          

            using (var context = new DatabaseContext())
            {
                var EmployeesList = (from s in context.Employees where s.EmployeeUserName == this.userNameField.Text select s).ToList<Employee>();
                var EmployeeGrade =(from s in context.Employees where s.EmployeeUserName == this.userNameField.Text && s.EmployeePassWord==this.userPasswordField.Password select s).ToList<Employee>();

                //if (EmployeeGrade.Count > 0)
                //{
                //    grade = EmployeeGrade[0].EmployeeJob;
                //}

                if (EmployeesList.Count > 0)
                {
                    if (EmployeesList[0].EmployeeUserName == this.userNameField.Text && EmployeesList[0].EmployeePassWord == this.userPasswordField.Password)
                    {
                        MessageBox.Show(" Welcome: " + EmployeesList[0].EmployeeJob + ", " + EmployeesList[0].EmployeeFirstName + " " + EmployeesList[0].EmployeeLastName);
                        //MainWindow mw = new MainWindow();
                        //Application.Current.MainWindow = mw;
                        Application.Current.MainWindow.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Entries" );
                        this.userPasswordField.Clear();
                        this.userNameField.Clear();
                        this.userNameField.Focus();


                    }
                }
                else
                {
                   
                        MessageBox.Show("   " + "Invalid Entries" + "   \n"+"   " +"Attempts reset :" + (x));
                    this.userPasswordField.Clear();
                    this.userNameField.Clear();

                    Att--;
                        x--;
                   
                   
                    if (Att < 1)
                    {
                        MessageBox.Show("   "+" Shutdown   \n"+"    " + "  Contanct © FONDOK-DEV.TEAM ","fondok",MessageBoxButton.OK);
                        Application.Current.Shutdown();
                        Process.GetCurrentProcess().Kill();
                    }
                }



                

                //MessageBox.Show(EmployeesList[0].EmployeeUserName + EmployeesList[0].EmployeeEMail + EmployeesList.Count());



            }




        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("Good Bye From LoginWindow :)!");
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit?", "Exit from Fondok", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Good Bye :) ", "Fondok");

                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();

                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }

            

        }

        private void userNameField_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                LoginClick(this, new RoutedEventArgs());
            }
        }

        private void userPasswordField_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                LoginClick(this, new RoutedEventArgs());
            }

        }
    }
}
