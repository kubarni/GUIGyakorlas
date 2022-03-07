using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GUIGyakorlas
{
    class ProgressBarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Side valami = (Side)value;
            
            if ((Side)value == Side.good)
            {
                return Brushes.Green;
                
            }
            else if ((Side)Enum.Parse(typeof(Side), value.ToString()) == Side.evil)
            {
                return Brushes.LightCoral;
            }
            else
            {
                return Brushes.Yellow;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
