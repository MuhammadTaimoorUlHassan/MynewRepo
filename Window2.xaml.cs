using System.Windows;
using System.Windows.Media;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string typeofstriker = "";
        public Window2()
        {
            InitializeComponent();
        }

        private void playerbutton_Click(object sender, RoutedEventArgs e)
        {
            stiker_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            striker_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            striker_.Foreground = Brushes.White;
            coach_border.Background = Brushes.White;
            coach_.Background = Brushes.White;
            coach_.Foreground = Brushes.Black;
            typeofstriker = "Striker";
            
        }

        private void coachbutton_Click(object sender, RoutedEventArgs e)
        {
            coach_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            coach_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            coach_.Foreground = Brushes.White;
            stiker_border.Background = Brushes.White;
            striker_.Background = Brushes.White;
            striker_.Foreground = Brushes.Black;
            typeofstriker = "Coach";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(typeofstriker == "")
            {
                MessageBox.Show("Select Type");
            }
            else
            {
                Window3 win3 = new Window3(typeofstriker);
                win3.Show();
                this.Close();
            }
            
        }
    }
}
