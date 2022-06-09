using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer timer;
        int ctr = 0;
        public Window1(string email)
        {
            InitializeComponent();
            this.label1.Content = email;
            Timee.Content = DateTime.Now.ToString("hh:mm:ss tt");
            Datee.Content = DateTime.Now.ToString("dddd , dd MMM yyyy");
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Timee.Content = DateTime.Now.ToString("hh:mm:ss tt");
            Datee.Content = DateTime.Now.ToString("dddd , dd MMM yyyy");
            ctr++;
            if (ctr > 6)
            {
                   ctr = 1;
            }
            PlaySlideShow(ctr);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctr = 1;
            
            chkAutoPlay.IsChecked = true;
            timer.IsEnabled = chkAutoPlay.IsChecked.Value;
            //MessageBox.Show(timer.IsEnabled.ToString());
            PlaySlideShow(ctr);
        }

        private void PlaySlideShow(int ctr)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            string filename = ((ctr < 10) ? "Images2/image0" + ctr + ".jpeg" : "Images2/image" + ctr + ".jpeg");
            image.UriSource = new Uri(filename, UriKind.Relative);
            //MessageBox.Show(image.UriSource.ToString());
            image.EndInit();
            myImage.Source = image;
            myImage.Stretch = Stretch.Uniform;
        }
        class Information_new
        {

            public int No_of_cameras { get; set; }
            public int No_of_launch_moniter { get; set; }
            public int No_of_force_plates { get; set; }
        }

        private void LaunchMoniter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ForcePlates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //string ss5 = Cameras.SelectionBoxItem.ToString();
            //MessageBox.Show(ss5);
        }

        private void Cameras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            
            String ss2 = Cameras.Items.GetItemAt(Cameras.SelectedIndex).ToString();
            String ss = Cameras.SelectedItem.ToString();
            ComboBoxItem ss3 = (ComboBoxItem)Cameras.SelectedItem;
            String ss4 = ss3.Name;
            
            string ss5 = Cameras.SelectionBoxItem.ToString();
            MessageBox.Show(ss5);
            */

        }

        private void Camerasmultiple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem ComboItem = (ComboBoxItem)Camerasmultiple.SelectedItem;
            string name = ComboItem.Name;
            if (name == "Cam1")
            {
                Vel.Content = "45 km/h";
                heightt.Content = "7 Feet";
                Res.Content = "4K (1920X1080)";
                Film.Content = "50 mm";
            }
            else if (name == "Cam2")
            {
                Vel.Content = "50 km/h";
                heightt.Content = "9 Feet";
                Res.Content = "4K (3820X2160)";
                Film.Content = "60 mm";
                Anglee.Content = "180";
            }
            else
            {
                Vel.Content = "20 km/h";
                heightt.Content = "4 Feet";
                Res.Content = "K (640X480)";
                Film.Content = "30 mm";
                Anglee.Content = "90";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Information_new new_obj = new Information_new();

            String news = Cameras.SelectionBoxItem.ToString();
            new_obj.No_of_cameras = int.Parse(news);
            String news2 = LaunchMoniter.SelectionBoxItem.ToString();
            new_obj.No_of_launch_moniter = int.Parse(news2);
            String news3 = ForcePlates.SelectionBoxItem.ToString();
            new_obj.No_of_force_plates = int.Parse(news3);
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(new_obj);
            string JSON_result = JsonConvert.SerializeObject(new_obj);
            string emails = label1.Content.ToString();
            string path1 = @"History\";
            string path2 = System.IO.Path.Combine(path1, emails);

            // Create directory temp1 if it doesn't exist
            Directory.CreateDirectory(path2);
            string time2 = DateTime.Now.ToString("hh:mm:ss tt");
            string filename22 = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();

            string date2 = DateTime.Now.ToString("dddd , dd MMM yyyy");
            Timee.Content = DateTime.Now.ToString("hh:mm:ss tt");
            Datee.Content = DateTime.Now.ToString("dddd , dd MMM yyyy");

            string date3 = date2;
            string path01 = @"History\" + emails + @"\";
            string path02 = System.IO.Path.Combine(path01, date3);
            
            Directory.CreateDirectory(path02);
            string path03 = System.IO.Path.Combine(path02, filename22);
            Directory.CreateDirectory(path03);
            
            string filecreation = "Config.json";
            string path12 = path03;
            string path = path12 + @"\" + filecreation;
            
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSON_result.ToString());
                tw.Close();
            }
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void chkAutoPlay_Checked(object sender, RoutedEventArgs e)
        {
            timer.IsEnabled = chkAutoPlay.IsChecked.Value;
            MessageBox.Show(chkAutoPlay.IsChecked.Value.ToString());
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            ctr++;
            if (ctr > 6)
            {
                ctr = 1;
            }
            PlaySlideShow(ctr);
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            ctr--;
            if (ctr < 1)
            {
                ctr = 6;
            }
            PlaySlideShow(ctr);
        }

        private void logout1_Click(object sender, RoutedEventArgs e)
        {
            Window win1 = new Window();
            win1.Show();
            this.Close();
        }

        private void logout2_Click(object sender, RoutedEventArgs e)
        {
            Window win1 = new Window();
            win1.Show();
            this.Close();
        }
    }
}
