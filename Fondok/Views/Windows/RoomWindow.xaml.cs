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

namespace Fondok.Views.Windows
{
    /// <summary>
    /// Interaction logic for 
    /// </summary>
    public partial class RoomWindow : Window
    {
        public RoomWindow()
        {
            InitializeComponent();

            string[] RoomTypeList = new string[] { "Signle", "Double", "Double Double", "Twin", "InterConnecting", "Adjoining", "Duplex", "Cabana", "Studio", "Parlor", "Lenai", "Efficiency", "Hospitality", "Suite", "King BedRoom", "Queen BedRoom" };
            RoomTypeField.ItemsSource = RoomTypeList;

            string[] RoomStatusList = new string[] { "Reserved", "Not Reserved", "Out Service"};
            RoomStatusField.ItemsSource = RoomStatusList;
        }
        
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }
    }
}
