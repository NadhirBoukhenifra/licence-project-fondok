using Fondok.Models;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace Fondok.ViewModels
{
    //public class RoomsViewModel : BindableBase, IConfirmNavigationRequest
    public class RoomsViewModel : BindableBase, INotifyPropertyChanged
    {

    
        //public DataTable RoomsSource { get; set; }

        public RoomsViewModel()
        {
            //SQLiteDatabase DB = new SQLiteDatabase();

            //String Query = "select * from ROOMS";

            //RoomsSource = DB.GetDataTable(Query);

            //RoomsSource = DB.GetDataTable(Query);



        }


    }
}
