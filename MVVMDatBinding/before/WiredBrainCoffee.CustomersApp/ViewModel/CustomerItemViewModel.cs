using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    // This is made so that the model does not need to be exposed to view. 
    // Problem is that if we change something in Customer (model) this is not notified to the view. 
    // We could make a direct link using InotifyPropertyChanged , but this would architecture wise not be the best. 
    // Therefore we choose to make a viewModel
    public class CustomerItemViewModel : ViewModelBase
    {

        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;

        }


        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set 
            { _model.FirstName = value;
                RaisePropretyChanged();
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                RaisePropretyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                RaisePropretyChanged();
            }
        }


    }
}
