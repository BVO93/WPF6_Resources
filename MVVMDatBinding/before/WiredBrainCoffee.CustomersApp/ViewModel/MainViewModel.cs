using System;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
  
        private  ViewModelBase? _selectedViewModel;
      
        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);

        }

        private  async void SelectViewModel(object? parameter)
        {

            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
            
        }

        public ProductsViewModel ProductsViewModel { get; }
        public CustomersViewModel CustomersViewModel { get; }

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;

            set
            {
                _selectedViewModel = value;
                RaisePropretyChanged();
            }

        }


        public DelegateCommand SelectViewModelCommand { get; }


        public async override Task LoadAsync()
        {
            if(SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }



    }
}
