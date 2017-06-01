using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace UsePowerService.View
{
    public class WindowBase : Window
    {
        ResourceManager mRM = new ResourceManager("UsePowerService.Properties.Resources", typeof(WindowBase).Assembly);

        public WindowBase()
        {
            Uri iconUri = new Uri("pack://application:,,,/Resources/Icon1.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

        }
    }
}
