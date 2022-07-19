using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        // The only implementation needed for INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        // Simple method to raise event
        protected virtual void RaisePropretyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}

