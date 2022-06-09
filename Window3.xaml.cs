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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public string typeofstriker = "";
        public string handedness = "";
        public Window3(string typeofstriker2)
        {
            InitializeComponent();
            typeofstriker = typeofstriker2;

        }

        private void righthandbutton_Click(object sender, RoutedEventArgs e)
        {
            right_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            right_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            right_.Foreground = Brushes.White;
            left_border.Background = Brushes.White;
            left_.Background = Brushes.White;
            left_.Foreground = Brushes.Black;
            handedness = "Right Hand";
            righthandbutton.Focus();
        }

        private void lefthandbutton_Click(object sender, RoutedEventArgs e)
        {
            left_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            left_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            left_.Foreground = Brushes.White;
            right_border.Background = Brushes.White;
            right_.Background = Brushes.White;
            right_.Foreground = Brushes.Black;
            handedness = "Left Hand";
            lefthandbutton.Focus();
        }

        private void nextbutton_Click(object sender, RoutedEventArgs e)
        {
            if (handedness == "")
            {
                MessageBox.Show("Select Type");
            }
            else
            {
                Window4 win3 = new Window4(typeofstriker, handedness);
                win3.Show();
                this.Close();
            }
        }
    }
}
