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

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        public ReservationView()
        {
            DatabaseContext db = new DatabaseContext();
           ReservationDataInteraction rdi = new ReservationDataInteraction(db);
            foreach(var reservation in db.Reservations)
            {
                if (reservation.CheckOutDate < DateTime.Now.AddDays(-1))
                {
                    rdi.DeleteReservation(reservation.ReservationID);
                }
            }
            InitializeComponent();
        }
        void ReservationViewLoaded(object sender, RoutedEventArgs e)
        {
            ReservationsGrid.UpdateLayout();
            ReservationsGrid.Items.Refresh();

        }
    }
}
