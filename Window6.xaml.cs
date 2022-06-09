using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public int countt = 0;
        public string email2;
        public string nameofuser;
        public string profileimage;
        public Window6(string email_, string nameofuser_, string profileimage_)
        {
            InitializeComponent();
            email2 = email_;
            nameofuser = nameofuser_;
            profileimage = profileimage_;
            Headersettings();

        }
        public class Emailofpersonobject
        {
            public string Email { get; set; }
        }
        private void Headersettings()
        {
            /*
            string base64String;
            string nameofpersons;
            Emailofpersonobject newobj = new Emailofpersonobject();
            newobj.Email = email2;
            string JSON_result = JsonConvert.SerializeObject(newobj);
            var data = new StringContent(JSON_result, Encoding.UTF8, "application/json");
            var url = "http://localhost:5000/api/user/UserByEmail";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            //MessageBox.Show(response.StatusCode.ToString());
            string result = response.Content.ReadAsStringAsync().Result;
            JObject result2 = JObject.Parse(result);
            //MessageBox.Show(result);
            
            nameofpersons = result2["Username"].ToString();
            base64String = result2["image64bit"].ToString();
            */
            /*
            using (StreamReader file = File.OpenText("Signup.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                nameofpersons =  o2["Username"].ToString();
                base64String = o2["ProfilePictureB64"].ToString();

            }
            */
            byte[] imageBytes = Convert.FromBase64String(profileimage);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            BitmapImage bi = new BitmapImage();

            bi.BeginInit();

            MemoryStream ms1 = new MemoryStream();

            image.Save(ms1, ImageFormat.Bmp);

            ms.Seek(0, SeekOrigin.Begin);

            bi.StreamSource = ms;

            bi.EndInit();
            imageofperson.Source = bi;
            nameofperson.Content = nameofuser;
        }
        private void Border_Drop(object sender, DragEventArgs e)
        {

        }
        private void history__Click(object sender, RoutedEventArgs e)
        {
            history_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3")); ;
            history_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            history_.Foreground = Brushes.White;
            settings_border.Background = Brushes.White;
            settings_.Background = Brushes.White;
            settings_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_border.Background = Brushes.White;
            capture_.Background = Brushes.White;
            capture_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            History_Screen_1 history_Screen_1 = new History_Screen_1();
            history_Screen_1.Show();
            this.Close();
        }

        private void settings__Click(object sender, RoutedEventArgs e)
        {
            settings_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_.Foreground = Brushes.White;
            history_border.Background = Brushes.White;
            history_.Background = Brushes.White;
            history_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_border.Background = Brushes.White;
            capture_.Background = Brushes.White;
            capture_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            SettingWindow settingWindow = new SettingWindow(email2, nameofuser, profileimage, countt);
            settingWindow.Show();
            this.Close();
        }

        private void captureimage_Click(object sender, RoutedEventArgs e)
        {
            capture_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_.Foreground = Brushes.White;
            history_border.Background = Brushes.White;
            history_.Background = Brushes.White;
            history_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_border.Background = Brushes.White;
            settings_.Background = Brushes.White;
            settings_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            Window1 win1 = new Window1(email2);
            win1.Show();
            this.Close();
        }

        private void capture__Click(object sender, RoutedEventArgs e)
        {
            capture_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_.Foreground = Brushes.White;
            history_border.Background = Brushes.White;
            history_.Background = Brushes.White;
            history_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_border.Background = Brushes.White;
            settings_.Background = Brushes.White;
            settings_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            Window1 win1 = new Window1(email2);
            win1.Show();
            this.Close();
        }

        private void historyimage_Click(object sender, RoutedEventArgs e)
        {
            history_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            history_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            history_.Foreground = Brushes.White;
            settings_border.Background = Brushes.White;
            settings_.Background = Brushes.White;
            settings_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_border.Background = Brushes.White;
            capture_.Background = Brushes.White;
            capture_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
        }

        private void settingimage_Click(object sender, RoutedEventArgs e)
        {
            settings_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            settings_.Foreground = Brushes.White;
            history_border.Background = Brushes.White;
            history_.Background = Brushes.White;
            history_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            capture_border.Background = Brushes.White;
            capture_.Background = Brushes.White;
            capture_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006AB3"));
            SettingWindow settingWindow = new SettingWindow(email2, nameofuser, profileimage, countt);
            settingWindow.Show();
            this.Close();
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
