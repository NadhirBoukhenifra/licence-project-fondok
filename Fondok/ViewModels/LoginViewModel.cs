using Prism.Mvvm;
namespace Fondok.ViewModels
{
    class LoginViewModel : BindableBase
    {
        private string _title = "HMS Login";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }
    }
}