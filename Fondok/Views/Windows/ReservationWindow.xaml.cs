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
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        public ReservationWindow()
        {
            InitializeComponent();

            var context = new DatabaseContext();

            var RoomAva = (from s in context.Rooms where (s.RoomNumber == 1) select s.RoomNumber).ToArray();

            RoomNumberField.ItemsSource = RoomAva;
        }

        private void AddReservationClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }
    }
}
