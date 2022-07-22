using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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


        public virtual Task LoadAsync() => Task.CompletedTask;



    }
}

