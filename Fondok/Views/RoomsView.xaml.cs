using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using Fondok.ViewModels;

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
 
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            _Add_Room _Add_Room = new _Add_Room();

            _Add_Room.ShowDialog();

            //    RoomsGrid.Items.Refresh();




        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RoomsGrid.Items.Refresh();
            //MessageBox.Show("hg");
        }

        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
