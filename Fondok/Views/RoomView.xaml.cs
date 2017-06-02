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
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
            DataContext = new RoomViewModel();
        }
        private void AddRoomsClick(object sender, RoutedEventArgs e)
        {
            RoomWindow RoomWindow = new RoomWindow();
            RoomWindow.ShowDialog();
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