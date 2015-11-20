using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientLocationBroadcastingTerminal
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public void Set<T>(ref T oldValue, T newValue, [CallerMemberName]string propertyName="")
        {
            if (oldValue == null || !oldValue.Equals(newValue))
            {
                oldValue = newValue;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}