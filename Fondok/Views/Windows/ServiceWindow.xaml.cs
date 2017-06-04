using Fondok.Context;
using Fondok.Models;
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
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();

            //using (var context = new DatabaseContext())
            //{
            //    var EmployeesList = (from s in context.Employees select s).ToList<Employee>();

            //}
           

    }
    private void AddServiceClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;


            
        }
    }
}
