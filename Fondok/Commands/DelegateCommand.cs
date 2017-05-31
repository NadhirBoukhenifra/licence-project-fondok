using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fondok.Commands
{
    internal class DelegateCommand : ICommand
    {
        private Action act;

        public DelegateCommand(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            act = action;

        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
            = delegate { };

        public void Execute(object parameter)
        {
            act();
        }

    }
}
