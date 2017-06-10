using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fondok.Commands
{
    class Verifications
    {

        public void JustChar(object sender, KeyEventArgs e)
        {

            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9)
                 || e.Key == Key.OemQuestion || e.Key == Key.OemPlus
 || e.Key == Key.OemOpenBrackets || e.Key == Key.OemComma || e.Key == Key.OemQuotes
|| e.Key == Key.OemSemicolon || e.Key == Key.OemTilde || e.Key == Key.OemOpenBrackets || e.Key == Key.OemPeriod
|| e.Key == Key.OemMinus || e.Key == Key.OemPipe || e.Key == Key.OemCloseBrackets || e.Key == Key.OemBackslash
|| e.Key == Key.OemPlus || e.Key == Key.Decimal || e.Key == Key.Add || e.Key == Key.Divide || e.Key == Key.Multiply
|| e.Key == Key.Subtract || e.Key == Key.Space
                )

            {
                e.Handled = true;
            }

        }

        //if (e.Key >= Key.A && e.Key <= Key.Z)
        //{
        //}
        //else
        //{
        //    e.Handled = true;
        //}


    }
}
