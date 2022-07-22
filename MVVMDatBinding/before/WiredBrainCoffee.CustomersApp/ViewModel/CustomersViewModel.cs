using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{

    public class CustomersViewModel : ViewModelBase
    {
        // Providing data from dataProvider
        private readonly ICustomerDataProvider _customerDataProvider;

      

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }


        // Observes when the collection is changed and gets update
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        // ? can be null
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                // RaisePropretyChanged(nameof(SelectedCustomer));
                RaisePropretyChanged();

                RaisePropretyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        // We want to check if there is a cusomter selected. If not we want details like name to be invisible. 
        // We check if customer is selected. Ans also raise the raisepropertyChanged event when a custoemr gets selected or deselected.
        public bool IsCustomerSelected => SelectedCustomer is not null;

        public NavigationSide navigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropretyChanged();
            }
        }


        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
       
        public async override Task LoadAsync()
        {
            // Check if there is already anyting in customers.
            if (Customers.Any())
            {
                return;
            }
            // GetAllAsync is method of dataProvider
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }

        }

        // Adding customer 
        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;

        }

        private void MoveNavigation(object? parameter)
        {

            if (_navigationSide == NavigationSide.Left)
            {
                navigationSide = NavigationSide.Right;
            }
            else
            {
                navigationSide = NavigationSide.Left;
            }

        }



        private void Delete(object? parameter)
        {
            if(SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }


        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }



        public enum NavigationSide
        {
            Left, 
            Right
        }


    }
}

