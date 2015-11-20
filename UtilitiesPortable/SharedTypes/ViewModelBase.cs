using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UtilitiesPortable.SharedTypes
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void Set<T>(ref T oldValue, T newValue, [CallerMemberName]string propertyName = "")
        {
            if (oldValue == null || !oldValue.Equals(newValue))
            {
                oldValue = newValue;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}