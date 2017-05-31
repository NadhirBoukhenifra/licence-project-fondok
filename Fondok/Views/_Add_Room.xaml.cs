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
    /// Interaction logic for _Add_Room.xaml
    /// </summary>
    public partial class _Add_Room : Window
    {
        public _Add_Room()
        {
            InitializeComponent();
        }
        private bool successAdd = false;
        private void AddRoom_Button_Click(object sender, RoutedEventArgs e)
        {


            SQLiteDatabase DB = new SQLiteDatabase();


            Dictionary<String, String> data = new Dictionary<String, String>();
            if (
                RoomTypeField.Text != null && RoomTypeField.Text != "" &&
                RoomReservedField.Text != null && RoomReservedField.Text != "" &&
                RoomReservedFromField.Text != null && RoomReservedFromField.Text != "" &&
                RoomReservedToField.Text != null && RoomReservedToField.Text != "" &&
                RoomReservedByField.Text != null && RoomReservedByField.Text != ""
                )
            {
                data.Add("RoomType", RoomTypeField.Text);
                data.Add("Reserved", RoomReservedField.Text);
                data.Add("ReservedFrom", RoomReservedFromField.Text);
                data.Add("ReservedTo", RoomReservedToField.Text);
                data.Add("ReservedBy", RoomReservedByField.Text);

                try
                {
                    DB.Insert("Rooms", data);
                    successAdd = true;

                }
                catch (Exception crap)
                {
                    MessageBox.Show(crap.Message);
                }

            }
            else
            {
                MessageBox.Show("Add some Text");
               
            }
            if (successAdd)
            {
                this.Close();

            }


        }
    }
}
