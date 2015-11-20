using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientLocationBroadcastingTerminal.Utilities
{
    public class SelectableTextBox : TextBox
    {
        public SelectableTextBox() : base()
        {
            this.AddHandler(SelectableTextBox.KeyUpEvent, new RoutedEventHandler(HandleKeyUp));
        }

        private void HandleKeyUp(object sender, RoutedEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke.Key == Key.Space || ke.Key == Key.Delete || ke.Key == Key.Back)
            {
                ke.Handled = false;
            }
        }
    }
}