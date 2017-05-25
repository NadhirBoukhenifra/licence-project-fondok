using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fondok.ViewModels
{
    class LoginViewModel : BindableBase
    {
        private string _title = "HMS Login";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        
    }
}
