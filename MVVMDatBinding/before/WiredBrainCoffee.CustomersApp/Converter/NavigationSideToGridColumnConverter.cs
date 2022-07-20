

using System;
using System.Globalization;
using System.Windows.Data;
using static WiredBrainCoffee.CustomersApp.ViewModel.CustomersViewModel;

namespace WiredBrainCoffee.CustomersApp.Converter
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var navigationSide = (NavigationSide)value;
            return navigationSide == NavigationSide.Left
                ? 0  // Value for grid column. If left 0 is returned. Else 2 is returned.
                : 2;
     
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
