using Fondok.Context;
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
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        private int errorCount;
        public RoomWindow()
        {


            InitializeComponent();
            DataContext = this;


            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));

            string[] RoomTypeSource = new string[] { "Single", "Double", "Double Double" };

            RoomTypeField.ItemsSource = RoomTypeSource;

            string[] RoomStatusSource = new string[] { "Reserved", "Not Reserved", "Out Service" };

            RoomStatusField.ItemsSource = RoomStatusSource;
            RoomStatusField.SelectedIndex = -1;
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
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

    }
}
