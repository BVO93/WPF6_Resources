﻿using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.View
{
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel _viewModel;
        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            // set dataContect to the VM
            DataContext = _viewModel;
            // Make event for Loaded
            Loaded += CustomersView_Loaded;
        }

        // Fire event when there
        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);

            //var newColumn = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            var column = Grid.GetColumn(customerListGrid);

            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColumn);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            // Just call the viewmodel and make a method 
            _viewModel.Add();
        }
    }
}
