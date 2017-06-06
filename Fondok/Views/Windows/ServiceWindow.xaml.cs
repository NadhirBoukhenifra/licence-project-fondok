using Fondok.Context;
using Fondok.Models;
using Fondok.ViewModels;
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

            var context = new DatabaseContext();

            var ResponsibleList = (from s in context.Employees where(s.EmployeeID == 1) select s.EmployeeUserName).ToArray();
                     
            ResponsibleField.ItemsSource = ResponsibleList;
            
        }
    private void AddServiceClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            
        }
    }
}
