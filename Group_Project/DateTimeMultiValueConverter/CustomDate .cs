using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.DateTimeMultiValueConverter
{
    public class CustomDate : INotifyPropertyChanged,IDataErrorInfo
    {
        int day;
        int month;
        int year;
                     
        Dictionary<string, string> validationErrors = new Dictionary<string, string>();

        public string this[string columnName] => validationErrors.ContainsKey(columnName) ? validationErrors[columnName] : null;

        public int Day
        {
            get => day;
            set
            {
                day = value;
                validationErrors[nameof(Day)] = ValidateDay();
                NotifyPropertyChanged(nameof(Day));
            }
        }

        public int Month
        {
            get => month;
            set
            {
                month = value;
                validationErrors[nameof(Month)] = ValidateMonth();
                NotifyPropertyChanged(nameof(Month));

                //reevaluate day
                Day = Day;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                year = value;
                validationErrors[nameof(Year)] = ValidateYear();
                NotifyPropertyChanged(nameof(Year));

                //reevaluate day
                Day = Day;
            }
        }
        public string Error
        {
            get
            {
                if (!validationErrors.Values.Any(x => x != null))
                    return null;

                StringBuilder msg = new StringBuilder();
                foreach (var item in validationErrors.Values)
                {
                    if (item != null)
                        msg.AppendLine(item);
                }
                return msg.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        #region Private validation methods

        private string ValidateDay()
        {
            if (!validationErrors.ContainsKey(nameof(Day)))
                validationErrors.Add(nameof(Day), null);

            string message = null;

            if (day < 1)
                message = "Day can't be less than 1";

            try
            {
                int daysInMonth = DateTime.DaysInMonth(Year, Month);
                if (day > daysInMonth)
                    message = $"There are only {daysInMonth} days in {Year}.{Month}";
            }
            catch (Exception)
            {
                message = "Can not validate Day as Month and/or Year have incorrect values";
            }

            return message;
        }

        private string ValidateMonth()
        {
            if (!validationErrors.ContainsKey(nameof(Month)))
                validationErrors.Add(nameof(Month), null);

            string message = null;

            if (month < 1 || month > 12)
                message = "Month value should be between 1 and 12";

            return message;
        }

        private string ValidateYear()
        {
            if (!validationErrors.ContainsKey(nameof(Year)))
                validationErrors.Add(nameof(Year), null);

            string message = null;

            if (year < 1)
                message = "Year value can't be below 0";

            if (year > DateTime.MaxValue.Year)
                message = $"The max Year value supported is {DateTime.MaxValue.Year}";

            return message;
        }

        #endregion
    }


    //public string this[string columnName] => throw new NotImplementedException();

    //public string Error => throw new NotImplementedException();

    //public event PropertyChangedEventHandler PropertyChanged;
    
}
