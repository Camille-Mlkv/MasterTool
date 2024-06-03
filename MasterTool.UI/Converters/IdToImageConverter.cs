using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.Converters
{
    public class IdToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {

                string imagesFolderPath = DetailInformationPageViewModel.GetImagesFolderPath();
                string imagePath = Path.Combine(imagesFolderPath, $"{id}.png");
                if (File.Exists(imagePath))
                {
                    return ImageSource.FromFile(imagePath);
                }
                else
                {
                    return "placeholder.png";
                }

            }

            return "placeholder.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
