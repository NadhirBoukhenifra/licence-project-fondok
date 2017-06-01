using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using Fondok.ViewModels;
using System.Data.SQLite;

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();
           DataContext = new RoomsViewModel();


        }
 
        private void AddRoomsClick(object sender, RoutedEventArgs e)
        {
            RoomWindow RoomWindow = new RoomWindow();

            RoomWindow.ShowDialog();

           
            //    RoomsGrid.Items.Refresh();




        }

        private void RoomsViewLoaded(object sender, RoutedEventArgs e)
        {
            RoomsGrid.Items.Refresh();

            MessageBox.Show("RoomViewLoaded");
        }
      

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            RoomsGrid.Items.Refresh();
        }

        
    }
}
