using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Converters
{
    internal class TabViewModelToViewConverter : ValueConverterMarkupBase<TabViewModelToViewConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is BaseViewModel))
                throw new ArgumentException($"Converter requires an object of type {nameof(BaseViewModel)} to work");

            if (value is ViewModels.TabVacanciesViewModel)
            {
                return new Views.TabVacancies();
            }
            else if (value is ViewModels.TabResponsesViewModel)
            {
                return new Views.TabResponses();
            }
            else if (value is ViewModels.TabEmployeesViewModel)
            {
                return new Views.TabEmployees();
            }
            else if (value is ViewModels.TabPeopleViewModel)
            {
                return new Views.TabPeople();
            }
            else
                return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
