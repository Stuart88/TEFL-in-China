using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TEFL_App.Helpers;

namespace TEFL_App.Converters
{
    public class DatetoStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                null => "",
                _ => ((DateTime)value).ToStringCustom()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse(value as string);
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                null => Visibility.Visible,
                bool b => b ? Visibility.Visible : Visibility.Collapsed, 
                _ => Visibility.Visible
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ToCheckmarkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                bool b => b ? "✔" : "",
                int i => i == 1 ? "✔" : "",
                string s => string.IsNullOrEmpty(s) ? "" : "✔",
                _ => ""
            };
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class HighestValueFromStringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "0";

            List<int> scores = ((string)value).Split(',').Select(s => int.Parse(s)).ToList();

            if (scores.Count() > 0)
                return scores.Max().ToString();
            else
                return "0";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


    public class ExamAttemptsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0";
            else
                return ((string)value)
                    .Split(',')
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Count()
                    .ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
