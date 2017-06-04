using Fondok.Context;
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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            //var context = new DatabaseContext();

            //var EmployeeJobList = (from s in context.Employees select s.EmployeeUserName).ToArray();
            string[] EmployeeJobList = new string[] { "Admin", "Receptionist"};

            EmployeeJobField.ItemsSource = EmployeeJobList;


        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }
    }
}
