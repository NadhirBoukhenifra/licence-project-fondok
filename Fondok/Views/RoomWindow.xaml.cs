using Fondok.Context;
using Fondok.Models;
using Fondok.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for 
    /// </summary>
    public partial class RoomWindow : Window
    {
        public RoomWindow()
        {
            InitializeComponent();
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            
            DatabaseContext context = new DatabaseContext();

            //string name = "Bouha";
            //double salary = 100.00;
            //string designation = "MEd";

            //EmployeeMaster employee = new EmployeeMaster()
            //{
            //    EmpName = name,
            //    Designation = designation,
            //    Salary = salary
            //};
            Room rooms = new Room()
            {
                Type = RoomTypeField.Text,
                Reserved = RoomReservedField.Text,
                ReservedFrom = RoomReservedFromField.Text,
                ReservedTo = RoomReservedToField.Text,
                ReservedBy = RoomReservedByField.Text,
                Price = Convert.ToDouble(PriceField.Text)
            };
            context.Rooms.Add(rooms);
          
            context.SaveChanges();
            
        }
    }
}
