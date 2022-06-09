using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
            /*
            int i = 0;
            ManagementObjectCollection collection;
            using (var finddevice = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = finddevice.Get();
            foreach (var device in collection)
            {
                MessageBox.Show(i.ToString());
                MessageBox.Show(device.GetPropertyValue("DeviceID").ToString() + "     " + device.GetPropertyValue("Description").ToString());
                //MessageBox.Show(device.GetPropertyValue("Description").ToString());
                i++;

            }
            */
        }
    }
}
