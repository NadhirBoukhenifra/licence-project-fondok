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
    public partial class RoomWindow : Window
    {
        private int errorCount;
        public RoomWindow()
        {
            InitializeComponent();
            
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));
            string[] RoomTypeList = new string[] {
    "Signle",
    "Double",
    "Double Double",
    "Twin",
    "InterConnecting",
    "Adjoining",
    "Duplex",
    "Cabana",
    "Studio",
    "Parlor",
    "Lenai",
    "Efficiency",
    "Hospitality",
    "Suite",
    "King BedRoom",
    "Queen BedRoom"
   };
            RoomTypeField.ItemsSource = RoomTypeList;
            string[] RoomStatusList = new string[] {
    "Reserved",
    "Not Reserved",
    "Out Service"
   };
            RoomStatusField.ItemsSource = RoomStatusList;
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(RoomNumberField.ToString());

            DialogResult = true;
        }
        private void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
            {

                throw new Exception("Unexpected event args");
            }
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        errorCount++;
                        break;
                    }
                case ValidationErrorEventAction.Removed:
                    {
                        errorCount--;
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }

            AddRoomButton.IsEnabled = errorCount == 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new RoomViewModel();
            RoomViewModel an = new RoomViewModel();
            an.nRoomNumber = 111;
            //RoomNumberField.Text = "999";
            //RoomNumberField.Focus();

            //if (string.IsNullOrEmpty(RoomNumberField.Text.ToString()))
            //{
            //RoomNumberField.Text = "";
            //RoomFloorField.Text = "";
            //RoomCapacityField.Text = "";
            //RoomPriceField.Text = "";

            //RoomTypeField.SelectedIndex = 1;
            //RoomStatusField.SelectedIndex = 1;
            //}
            //RoomTypeField.SelectedIndex = 1;
            //MessageBox.Show(this.RoomTypeField..ToString());
        }
    }
}