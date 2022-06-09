using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        int counttt;
        public string nameofuser;
        public string profileimage;
        public string email2;
        public string unitsstring;
        public string speedunitsstring;
        public string distanceunitsstring;
        public bool lighttoggle;
        public bool soundtoggle;
        public string videoencodingstring;
        public string videorendingstring;
        public bool enablebuffering;
        public bool triggremicrophone;
        public bool launchmoniterenable;
        public bool quickenablebuffering;
        public bool hardwaretrackman;
        public bool hardwareflightscope;
        public bool hardwarefullswing;
        public bool hardwareforsight;
        public bool hardwareskytrak;
        public SettingWindow(string email_, string nameofuser_, string profileimage_, int countt)
        {
            InitializeComponent();
            int counter = 0;
            counttt = countt;
            profileimage = profileimage_;
            nameofuser = nameofuser_;
            email2 = email_;
            Headersettings();
            generalbtnclick();
            string filecreationofgeneral = "GeneralSettings.json";
            string filecreationofvideocapture = "VideoCaptureSettings.json";
            string filecreationofhardware = "HardwareSettings.json";
            string path3 = @"History\" + email2 + @"\";
            string path4 = path3 + filecreationofgeneral;
            if (File.Exists(path4))
            {
                counter = counter + 1;
            }
            string path5 = path3 + filecreationofvideocapture;
            if (File.Exists(path5))
            {
                counter = counter + 1;
            }
            string path6 = path3 + filecreationofhardware;
            if (File.Exists(path6))
            {
                counter = counter + 1;
            }
            string path7 = path3 + "settings.json";
            if (File.Exists(path7))
            {
                counter = counter + 1;
            }
            if(counter < 4)
            {
                //MessageBox.Show("In done");
                Donebtnsaved();
            }
            //Thread.Sleep(10000);
            if(countt == 1)
            {
                this.Close();
            }
            else { settingsdone(); }
            
        }
        private void settingsdone()
        {
            string filecreationofgeneral = "GeneralSettings.json";
            string filecreationofvideocapture = "VideoCaptureSettings.json";
            string filecreationofhardware = "HardwareSettings.json";
            string path3 = @"History\" + email2 + @"\";
            string path4 = path3 + filecreationofgeneral;
            //Thread.Sleep(5000);
            using (StreamReader file = File.OpenText(path4))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                string generalunits1 = o2["Units"].ToString();
                string generalspeedunits = o2["SpeedUnits"].ToString();
                string generaldistanceunits = o2["DistanceUnits"].ToString();
                if (generalunits1 == "M")
                {
                    units1_.IsChecked = true;
                }
                else
                {
                    units2_.IsChecked = true;
                }
                if (generalspeedunits == "MPH")
                {
                    speedunits2_.IsChecked = true;
                }
                else
                {
                    speedunits1_.IsChecked = true;
                }
                if (generaldistanceunits == "M")
                {
                    distanceunits1_.IsChecked = true;
                }
                else
                {
                    distanceunits2_.IsChecked = true;
                }
            }
            string path5 = path3 + filecreationofvideocapture;
            using (StreamReader file = File.OpenText(path5))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);

                string videocaptureencoding = o2["VideoEncoding"].ToString();
                string videocaptureredering = o2["VideoRendering"].ToString();
                bool videocaptureenablebuffering = (bool)o2["CaptureEnableBuffering"];
                if (videocaptureencoding == "CPU MPEG - 4 Part 2")
                {
                    videoencoding1_.IsChecked = true;
                }
                else if (videocaptureencoding == "GPU NVIDIA NVNEC H264")
                {
                    videoencoding2_.IsChecked = true;
                }
                else
                {
                    videoencoding3_.IsChecked = true;
                }
                if (videocaptureredering == "Enable DirectX accelerated rendering")
                {
                    videorendering1_.IsChecked = true;
                }
                else
                {
                    videorendering2_.IsChecked = true;
                }
                if (videocaptureenablebuffering == true)
                {
                    capture1_.IsChecked = true;

                }
                else
                {
                    
                    capture1_.IsChecked = false;
                }
            }
            string path6 = path3 + filecreationofhardware;
            using (StreamReader file = File.OpenText(path6))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);

                bool hardwaretriggremicrophone = (bool)o2["TriggerMicroPhone"];
                bool hardwarelaunchmoniter = (bool)o2["LaunchMoniterEnable"];
                bool hardwareenablebuffering = (bool)o2["EnableQuickBuffering"];
                bool hardwaretrackman = (bool)o2["TrackMan"];
                bool hardwareflightscope = (bool)o2["FlightScope"];
                bool hardwarefullswing = (bool)o2["FullSwing"];
                bool hardwareforesight = (bool)o2["ForeSight"];
                bool hardwareskytrack = (bool)o2["SkyTrack"];
                if(hardwaretriggremicrophone == true)
                {
                    microphone_.IsChecked = true;
                }
                else
                {
                    microphone_.IsChecked = false;
                }
                if(hardwarelaunchmoniter == true)
                {
                    launchmonitertoggle_.IsChecked = true;
                }
                else
                {
                    launchmonitertoggle_.IsChecked = false;
                }
                if(hardwareenablebuffering == true)
                {
                    enablequickbuffering_.IsChecked = true;
                }
                else
                {
                    enablequickbuffering_.IsChecked = false;
                }
                if(hardwaretrackman == true)
                {
                    trackman_.IsChecked = true;
                }
                else
                {
                    trackman_.IsChecked = false;
                }
                if(hardwareflightscope == true)
                {
                    flightscope_.IsChecked = true;
                }
                else
                {
                    flightscope_.IsChecked = false;
                }
                if(hardwarefullswing == true)
                {
                    fullswing_.IsChecked = true;
                }
                else
                {
                    fullswing_.IsChecked = false;
                }
                if(hardwareforesight == true)
                {
                    foresightgc2_.IsChecked = true;
                }
                else
                {
                    foresightgc2_.IsChecked = false;
                }
                if(hardwareskytrack == true)
                {
                    skytrack_.IsChecked = true;
                }
                else
                {
                    skytrack_.IsChecked = false;
                }
            }
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
        private void generalbtnclick()
        {
            buttonlabel_.Content = "General";
            generalbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            videocapturebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            hardwarebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            camerabtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            launchmoniterbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            general_border_.Visibility = Visibility.Visible;
            units_.Visibility = Visibility.Visible;
            units1_.Visibility = Visibility.Visible;
            units2_.Visibility = Visibility.Visible;
            launchmoniter.Visibility = Visibility.Visible;
            speedunits_.Visibility = Visibility.Visible;
            speedunits1_.Visibility = Visibility.Visible;
            speedunits2_.Visibility = Visibility.Visible;
            distanceunits_.Visibility = Visibility.Visible;
            distanceunits1_.Visibility = Visibility.Visible;
            distanceunits2_.Visibility = Visibility.Visible;
            notificationborder_.Visibility = Visibility.Visible;
            notifications_.Visibility = Visibility.Visible;
            lightlabel_.Visibility = Visibility.Visible;
            lighttoggle_.Visibility = Visibility.Visible;
            soundtoggle_.Visibility = Visibility.Visible;
            soundlabel_.Visibility = Visibility.Visible;
            soundimage_.Visibility = Visibility.Visible;


            generalimage_.Source = new BitmapImage(new Uri(@"Imagesused/generalimage1.png", UriKind.Relative));
            hardwareimage00_.Source = new BitmapImage(new Uri(@"Imagesused/hardware00.png", UriKind.Relative));
            hardwareimage01_.Source = new BitmapImage(new Uri(@"Imagesused/hardware01.png", UriKind.Relative));
            videocaptureimage_.Source = new BitmapImage(new Uri(@"Imagesused/videocaptureimage0.png", UriKind.Relative));

            videocapture_border_.Visibility = Visibility.Hidden;
            videoencoding_.Visibility = Visibility.Hidden;
            videoencoding1_.Visibility = Visibility.Hidden;
            videoencoding2_.Visibility = Visibility.Hidden;
            videoencoding3_.Visibility = Visibility.Hidden;
            videoencoding4_.Visibility = Visibility.Hidden;
            videorendering1_.Visibility = Visibility.Hidden;
            videorendering_.Visibility = Visibility.Hidden;
            videorendering2_.Visibility = Visibility.Hidden;
            videorendering3_.Visibility = Visibility.Hidden;
            capture_.Visibility = Visibility.Hidden;
            capture1_.Visibility = Visibility.Hidden;
            capture2_.Visibility = Visibility.Hidden;
            capture3_.Visibility = Visibility.Hidden;


            sensorplate_.Visibility = Visibility.Hidden;
            autodetectbtn_.Visibility = Visibility.Hidden;
            triggerdevice_.Visibility = Visibility.Hidden;
            microphone_.Visibility = Visibility.Hidden;
            intelsst_.Visibility = Visibility.Hidden;
            configutebtn_.Visibility = Visibility.Hidden;
            launchmoniterhardware_.Visibility = Visibility.Hidden;
            launchmonitertoggle_.Visibility = Visibility.Hidden;
            enablequickbuffering_.Visibility = Visibility.Hidden;
            trackman_.Visibility = Visibility.Hidden;
            trackmannot_.Visibility = Visibility.Hidden;
            flightscope_.Visibility = Visibility.Hidden;
            flightscopenot_.Visibility = Visibility.Hidden;
            fullswing_.Visibility = Visibility.Hidden;
            fullswingnot_.Visibility = Visibility.Hidden;
            foresightnot_.Visibility = Visibility.Hidden;
            foresightgc2_.Visibility = Visibility.Hidden;
            skytrack_.Visibility = Visibility.Hidden;
            skytracknot_.Visibility = Visibility.Hidden;
            hardwareborder_.Visibility = Visibility.Hidden;
            hardwareborder2_.Visibility = Visibility.Hidden;
        }
        private void generalbtn__Click(object sender, RoutedEventArgs e)
        {
            generalbtnclick();
        }

        private void videocapturebtn__Click(object sender, RoutedEventArgs e)
        {
            buttonlabel_.Content = "Video & Capture";
            generalbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            videocapturebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            hardwarebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            camerabtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            launchmoniterbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            generalimage_.Source = new BitmapImage(new Uri(@"Imagesused/generalimage0.png", UriKind.Relative));
            videocaptureimage_.Source = new BitmapImage(new Uri(@"Imagesused/videocaptureimage1.png", UriKind.Relative));
            hardwareimage00_.Source = new BitmapImage(new Uri(@"Imagesused/hardware00.png", UriKind.Relative));
            hardwareimage01_.Source = new BitmapImage(new Uri(@"Imagesused/hardware01.png", UriKind.Relative));

            videocapture_border_.Visibility = Visibility.Visible;
            videoencoding_.Visibility = Visibility.Visible;
            videoencoding1_.Visibility = Visibility.Visible;
            videoencoding2_.Visibility = Visibility.Visible;
            videoencoding3_.Visibility = Visibility.Visible;
            videoencoding4_.Visibility = Visibility.Visible;
            videorendering1_.Visibility = Visibility.Visible;
            videorendering_.Visibility = Visibility.Visible;
            videorendering2_.Visibility = Visibility.Visible;
            videorendering3_.Visibility = Visibility.Visible;
            capture_.Visibility = Visibility.Visible;
            capture1_.Visibility = Visibility.Visible;
            capture2_.Visibility = Visibility.Visible;
            capture3_.Visibility = Visibility.Visible;



            general_border_.Visibility = Visibility.Hidden;
            units_.Visibility = Visibility.Hidden;
            units1_.Visibility = Visibility.Hidden;
            units2_.Visibility = Visibility.Hidden;
            launchmoniter.Visibility = Visibility.Hidden;
            speedunits_.Visibility = Visibility.Hidden;
            speedunits1_.Visibility = Visibility.Hidden;
            speedunits2_.Visibility = Visibility.Hidden;
            distanceunits_.Visibility = Visibility.Hidden;
            distanceunits1_.Visibility = Visibility.Hidden;
            distanceunits2_.Visibility = Visibility.Hidden;
            notificationborder_.Visibility = Visibility.Hidden;
            notifications_.Visibility = Visibility.Hidden;
            lightlabel_.Visibility = Visibility.Hidden;
            lighttoggle_.Visibility = Visibility.Hidden;
            soundlabel_.Visibility = Visibility.Hidden;
            soundimage_.Visibility = Visibility.Hidden;
            soundtoggle_.Visibility = Visibility.Hidden;

            sensorplate_.Visibility = Visibility.Hidden;
            autodetectbtn_.Visibility = Visibility.Hidden;
            triggerdevice_.Visibility = Visibility.Hidden;
            microphone_.Visibility = Visibility.Hidden;
            intelsst_.Visibility = Visibility.Hidden;
            configutebtn_.Visibility = Visibility.Hidden;
            launchmoniterhardware_.Visibility = Visibility.Hidden;
            launchmonitertoggle_.Visibility = Visibility.Hidden;
            enablequickbuffering_.Visibility = Visibility.Hidden;
            trackman_.Visibility = Visibility.Hidden;
            trackmannot_.Visibility = Visibility.Hidden;
            flightscope_.Visibility = Visibility.Hidden;
            flightscopenot_.Visibility = Visibility.Hidden;
            fullswing_.Visibility = Visibility.Hidden;
            fullswingnot_.Visibility = Visibility.Hidden;
            foresightnot_.Visibility = Visibility.Hidden;
            foresightgc2_.Visibility = Visibility.Hidden;
            skytrack_.Visibility = Visibility.Hidden;
            skytracknot_.Visibility = Visibility.Hidden;
            hardwareborder_.Visibility = Visibility.Hidden;
            hardwareborder2_.Visibility = Visibility.Hidden;
        }

        private void hardwarebtn__Click(object sender, RoutedEventArgs e)
        {
            generalbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            videocapturebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            hardwarebtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            camerabtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            launchmoniterbtn_.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9499C3"));
            hardwareimage00_.Source = new BitmapImage(new Uri(@"Imagesused/hardwareimage10.png", UriKind.Relative));
            hardwareimage01_.Source = new BitmapImage(new Uri(@"Imagesused/hardwareimage11.png", UriKind.Relative));

            generalimage_.Source = new BitmapImage(new Uri(@"Imagesused/generalimage0.png", UriKind.Relative));
            videocaptureimage_.Source = new BitmapImage(new Uri(@"Imagesused/videocaptureimage0.png", UriKind.Relative));
            buttonlabel_.Content = "Hardware";
            general_border_.Visibility = Visibility.Hidden;
            units_.Visibility = Visibility.Hidden;
            units1_.Visibility = Visibility.Hidden;
            units2_.Visibility = Visibility.Hidden;
            launchmoniter.Visibility = Visibility.Hidden;
            speedunits_.Visibility = Visibility.Hidden;
            speedunits1_.Visibility = Visibility.Hidden;
            speedunits2_.Visibility = Visibility.Hidden;
            distanceunits_.Visibility = Visibility.Hidden;
            distanceunits1_.Visibility = Visibility.Hidden;
            distanceunits2_.Visibility = Visibility.Hidden;
            notificationborder_.Visibility = Visibility.Hidden;
            notifications_.Visibility = Visibility.Hidden;
            lightlabel_.Visibility = Visibility.Hidden;
            lighttoggle_.Visibility = Visibility.Hidden;
            soundlabel_.Visibility = Visibility.Hidden;
            soundimage_.Visibility = Visibility.Hidden;
            soundtoggle_.Visibility = Visibility.Hidden;

            videocapture_border_.Visibility = Visibility.Hidden;
            videoencoding_.Visibility = Visibility.Hidden;
            videoencoding1_.Visibility = Visibility.Hidden;
            videoencoding2_.Visibility = Visibility.Hidden;
            videoencoding3_.Visibility = Visibility.Hidden;
            videoencoding4_.Visibility = Visibility.Hidden;
            videorendering1_.Visibility = Visibility.Hidden;
            videorendering_.Visibility = Visibility.Hidden;
            videorendering2_.Visibility = Visibility.Hidden;
            videorendering3_.Visibility = Visibility.Hidden;
            capture_.Visibility = Visibility.Hidden;
            capture1_.Visibility = Visibility.Hidden;
            capture2_.Visibility = Visibility.Hidden;
            capture3_.Visibility = Visibility.Hidden;

            sensorplate_.Visibility = Visibility.Visible;
            autodetectbtn_.Visibility = Visibility.Visible;
            triggerdevice_.Visibility = Visibility.Visible;
            microphone_.Visibility = Visibility.Visible;
            intelsst_.Visibility = Visibility.Visible;
            configutebtn_.Visibility = Visibility.Visible;
            launchmoniterhardware_.Visibility = Visibility.Visible;
            launchmonitertoggle_.Visibility = Visibility.Visible;
            enablequickbuffering_.Visibility = Visibility.Visible;
            trackman_.Visibility = Visibility.Visible;
            trackmannot_.Visibility = Visibility.Visible;
            flightscope_.Visibility = Visibility.Visible;
            flightscopenot_.Visibility = Visibility.Visible;
            fullswing_.Visibility = Visibility.Visible;
            fullswingnot_.Visibility = Visibility.Visible;
            foresightnot_.Visibility = Visibility.Visible;
            foresightgc2_.Visibility = Visibility.Visible;
            skytrack_.Visibility = Visibility.Visible;
            skytracknot_.Visibility = Visibility.Visible;
            hardwareborder_.Visibility = Visibility.Visible;
            hardwareborder2_.Visibility = Visibility.Visible;
        }
        class SettingsHardware
        {
            public bool TriggerMicroPhone { get; set; }
            public bool LaunchMoniterEnable { get; set; }
            public bool EnableQuickBuffering { get; set; }
            public bool TrackMan { get; set; }
            public bool FlightScope { get; set; }
            public bool FullSwing { get; set; }
            public bool ForeSight { get; set; }
            public bool SkyTrack { get; set; }
        }
        class SettingsVideoCapture
        {
            public string VideoEncoding { get; set; }
            public string VideoRendering { get; set; }
            public bool CaptureEnableBuffering { get; set; }
        }
        class SettingsGeneral
        {
            public string Email { get; set; }
            public string Units { get; set; }
            public string SpeedUnits { get; set; }
            public string DistanceUnits { get; set; }
        }
        class SettingsJson
        {
            public string Email { get; set; }
            public string Units { get; set; }
            public string SpeedUnits { get; set; }
            public string DistanceUnits { get; set; }
            public bool Lights { get; set; }
            public bool Sounds { get; set; }
            public string VideoEncoding { get; set; }
            public string VideoRendering { get; set; }
            public bool CaptureEnableBuffering { get; set; }
            public bool TriggerMicroPhone { get; set; }
            public bool LaunchMoniterEnable { get; set; }
            public bool EnableQuickBuffering { get; set; }
            public bool TrackMan { get; set; }
            public bool FlightScope { get; set; }
            public bool FullSwing { get; set; }
            public bool ForeSight { get; set; }
            public bool SkyTrack { get; set; }
        }
        private async void Savesettingstoapi(string json)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5000/api/settings/save";
            var client = new HttpClient();
            //MessageBox.Show(json);
            var response = await client.PostAsync(url, data);

            //Thread.Sleep(9000);
            string result = response.Content.ReadAsStringAsync().Result;
            string filecreationofgeneral = "GeneralSettings.json";
            string path1 = @"History\";
            string path2 = System.IO.Path.Combine(path1, email2);
            string JSON_General = JsonConvert.SerializeObject(json);
            Directory.CreateDirectory(path2);
            //MessageBox.Show(JSON_General.ToString());
            string path3 = @"History\" + email2 + @"\";
            string path4 = System.IO.Path.Combine(path3, filecreationofgeneral);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(JSON_General);
                tw.Close();
                //MessageBox.Show("Done with file");
            }
            //MessageBox.Show(result);
        }
        private async void Getsettingsfromapi()
        {
            
            string generalunits1;
            string generalspeedunits;
            string generaldistanceunits;
            Emailofpersonobject newobj = new Emailofpersonobject();
            newobj.Email = email2;
            string JSON_result = JsonConvert.SerializeObject(newobj);
            var data = new StringContent(JSON_result, Encoding.UTF8, "application/json");
            var url = "http://localhost:5000/api/settings/getSettingsByEmail";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            //MessageBox.Show(response.StatusCode.ToString());
            string result = response.Content.ReadAsStringAsync().Result;
            JObject result2 = JObject.Parse(result);

            generalunits1 = result2["Units"].ToString();
            generalspeedunits = result2["SpeedUnits"].ToString();
            generaldistanceunits = result2["DistanceUnits"].ToString();
            SettingsGeneral settingsGeneral = new SettingsGeneral();
            settingsGeneral.Email = email2;
            settingsGeneral.Units = generalunits1;
            settingsGeneral.SpeedUnits = generalspeedunits;
            settingsGeneral.DistanceUnits = generaldistanceunits;
            string filecreationofgeneral = "GeneralSettings.json";
            string path1 = @"History\";
            string path2 = System.IO.Path.Combine(path1, email2);
            string JSON_General = JsonConvert.SerializeObject(settingsGeneral);
            Directory.CreateDirectory(path2);
            //MessageBox.Show(JSON_General.ToString());
            string path3 = @"History\" + email2 + @"\";
            string path4 = System.IO.Path.Combine(path3, filecreationofgeneral);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(JSON_General);
                tw.Close();
                //MessageBox.Show("Done with file");
            }

        }
        private void Donebtnsaved()
        {
            if (!(bool)lighttoggle_.IsChecked)
            {
                lighttoggle = false;
            }
            if (!(bool)soundtoggle_.IsChecked)
            {
                soundtoggle = false;
            }
            if (!(bool)capture1_.IsChecked)
            {
                enablebuffering = false;
            }
            if (!(bool)microphone_.IsChecked)
            {
                triggremicrophone = false;
            }
            if (!(bool)launchmonitertoggle_.IsChecked)
            {
                launchmoniterenable = false;
            }
            if (!(bool)enablequickbuffering_.IsChecked)
            {
                quickenablebuffering = false;
            }
            if (!(bool)trackman_.IsChecked)
            {
                hardwaretrackman = false;
            }
            if (!(bool)flightscope_.IsChecked)
            {
                hardwareflightscope = false;
            }
            if (!(bool)fullswing_.IsChecked)
            {
                hardwarefullswing = false;
            }
            if (!(bool)foresightgc2_.IsChecked)
            {
                hardwareforsight = false;
            }
            if (!(bool)skytrack_.IsChecked)
            {
                hardwareskytrak = false;
            }
            SettingsJson newobj = new SettingsJson();
            SettingsGeneral settingsGeneral = new SettingsGeneral();
            SettingsVideoCapture settingsVideoCapture = new SettingsVideoCapture();
            SettingsHardware settingsHardware = new SettingsHardware();
            newobj.Email = email2;
            newobj.Units = unitsstring;
            newobj.SpeedUnits = speedunitsstring;
            newobj.DistanceUnits = distanceunitsstring;
            newobj.Lights = lighttoggle;
            newobj.Sounds = soundtoggle;
            newobj.VideoEncoding = videoencodingstring;
            newobj.VideoRendering = videorendingstring;
            newobj.CaptureEnableBuffering = enablebuffering;
            newobj.TriggerMicroPhone = triggremicrophone;
            newobj.LaunchMoniterEnable = launchmoniterenable;
            newobj.EnableQuickBuffering = quickenablebuffering;
            newobj.TrackMan = hardwaretrackman;
            newobj.FlightScope = hardwareflightscope;
            newobj.FullSwing = hardwarefullswing;
            newobj.ForeSight = hardwareforsight;
            newobj.SkyTrack = hardwareskytrak;

            settingsGeneral.Email = email2;
            settingsGeneral.Units = unitsstring;
            settingsGeneral.SpeedUnits = speedunitsstring;
            settingsGeneral.DistanceUnits = distanceunitsstring;

            settingsVideoCapture.VideoEncoding = videoencodingstring;
            settingsVideoCapture.VideoRendering = videorendingstring;
            settingsVideoCapture.CaptureEnableBuffering = enablebuffering;


            settingsHardware.TriggerMicroPhone = triggremicrophone;
            settingsHardware.LaunchMoniterEnable = launchmoniterenable;
            settingsHardware.EnableQuickBuffering = quickenablebuffering;
            settingsHardware.TrackMan = hardwaretrackman;
            settingsHardware.FlightScope = hardwareflightscope;
            settingsHardware.FullSwing = hardwarefullswing;
            settingsHardware.ForeSight = hardwareforsight;
            settingsHardware.SkyTrack = hardwareskytrak;



            string JSON_result = JsonConvert.SerializeObject(newobj);
            string JSON_General = JsonConvert.SerializeObject(settingsGeneral);
            string JSON_VideoCapture = JsonConvert.SerializeObject(settingsVideoCapture);
            string JSON_Hardware = JsonConvert.SerializeObject(settingsHardware);
            string filecreationofvideocapture = "VideoCaptureSettings.json";
            string filecreationofhardware = "HardwareSettings.json";
            if(counttt == 0)
            {
                Savesettingstoapi(JSON_General);
            }
            //Thread.Sleep(5000);
            if(counttt == 1)
            {
                Getsettingsfromapi();
            }
            //Thread.Sleep(5000);
            //MessageBox.Show("After Getting");
            string emails = email2;
            
            string path1 = @"History\";
            string path2 = System.IO.Path.Combine(path1, emails);

            Directory.CreateDirectory(path2);
            
            string path31 = @"History\" + emails + @"\";
            string path41 = System.IO.Path.Combine(path31, filecreationofvideocapture);
            using (var tw = new StreamWriter(path41, false))
            {
                tw.WriteLine(JSON_VideoCapture.ToString());
                tw.Close();
            }
            string path32 = @"History\" + emails + @"\";
            string path42 = System.IO.Path.Combine(path32, filecreationofhardware);
            using (var tw = new StreamWriter(path42, false))
            {
                tw.WriteLine(JSON_Hardware.ToString());
                tw.Close();
            }
            string path33 = @"History\" + emails + @"\";
            string filecreation = "settings.json";
            string path43 = System.IO.Path.Combine(path33, filecreation);

            using (var tw = new StreamWriter(path43, false))
            {
                tw.WriteLine(JSON_result.ToString());
                tw.Close();
            }
            
        }
        private void Donebtn_Click(object sender, RoutedEventArgs e)
        {
            counttt = 0;
            Donebtnsaved();
            Window6 win6 = new Window6(email2, nameofuser, profileimage);
            win6.Show();
            this.Close();
        }
        private void units1__Checked_1(object sender, RoutedEventArgs e)
        {
            unitsstring = "M";
        }
        private void units2__Checked(object sender, RoutedEventArgs e)
        {
            unitsstring = "YD";
        }
        private void speedunits1__Checked(object sender, RoutedEventArgs e)
        {
            speedunitsstring = "KM";
        }
        private void speedunits2__Checked(object sender, RoutedEventArgs e)
        {
            speedunitsstring = "MPH";
        }
        private void distanceunits1__Checked(object sender, RoutedEventArgs e)
        {
            distanceunitsstring = "M";
        }
        private void distanceunits2__Checked(object sender, RoutedEventArgs e)
        {
            distanceunitsstring = "YD";
        }
        private void lighttoggle__Checked(object sender, RoutedEventArgs e)
        {
            lighttoggle = true;
        }
        private void soundtoggle__Checked(object sender, RoutedEventArgs e)
        {
            soundtoggle = true;
        }
        private void videoencoding1__Checked(object sender, RoutedEventArgs e)
        {
            videoencodingstring = videoencoding1_.Content.ToString ();
        }
        private void videoencoding2__Checked(object sender, RoutedEventArgs e)
        {
            videoencodingstring = videoencoding2_.Content.ToString () ;
        }
        private void videoencoding3__Checked(object sender, RoutedEventArgs e)
        {
            videoencodingstring = videoencoding3_.Content.ToString();
        }
        private void videorendering1__Checked(object sender, RoutedEventArgs e)
        {
            videorendingstring = videorendering1_.Content.ToString();
        }
        private void videorendering2__Checked(object sender, RoutedEventArgs e)
        {
            videorendingstring = videorendering2_.Content.ToString();
        }
        private void capture1__Checked(object sender, RoutedEventArgs e)
        {
            enablebuffering = true;
        }
        private void microphone__Checked(object sender, RoutedEventArgs e)
        {
            triggremicrophone = true;
        }
        private void configutebtn__Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void launchmonitertoggle__Checked(object sender, RoutedEventArgs e)
        {
            launchmoniterenable = true;
        }
        private void enablequickbuffering__Checked(object sender, RoutedEventArgs e)
        {
            quickenablebuffering = true;
        }
        private void trackman__Checked(object sender, RoutedEventArgs e)
        {
            hardwaretrackman = true;
        }

        private void flightscope__Checked(object sender, RoutedEventArgs e)
        {
            hardwareflightscope = true;
        }

        private void foresightgc2__Checked(object sender, RoutedEventArgs e)
        {
            hardwareforsight = true;
        }

        private void skytrack__Checked(object sender, RoutedEventArgs e)
        {
            hardwareskytrak = true;
        }

        private void fullswing__Checked(object sender, RoutedEventArgs e)
        {
            hardwarefullswing = true;
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
    