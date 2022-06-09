using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string responsefromhttps;
        public string profileimage;
        int countt = 1;
        public string nameofuser;

        public MainWindow()
        {
            InitializeComponent();
            Filecreation();

        }
        public void GetAllConnectedCameras()
        {
            Dictionary<string, string> EmployeeList2 = new Dictionary<string, string>();
            int j = 0;
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    string newvariable = device["Caption"].ToString();
                    EmployeeList2.Add(j.ToString(), newvariable);
                    j++;
                }
                                                                                    
            }
            string newvalue2 = JsonConvert.SerializeObject(EmployeeList2);
            string filecreationofconnectedcameras = "ConnectedCameras.json";
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofconnectedcameras);
           
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(newvalue2.ToString());
                tw.Close();
            }

        }
        public void GetAllConnectedUSBDevices()
        {
            int i = 0;
            ManagementObjectCollection collection;
            Dictionary<string, Dictionary<string, string>> USBConnected = new Dictionary<string, Dictionary<string, string>>();
            using (var finddevice = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = finddevice.Get();
            foreach (var device in collection)
            {
                string deviceid = device.GetPropertyValue("DeviceID").ToString();
                string devicedescription = device.GetPropertyValue("Description").ToString();
                USBConnected.Add(i.ToString(), new Dictionary<string, string>
                {
                    {deviceid, devicedescription},
                });
                i++;
            }
            string USB_Json  = JsonConvert.SerializeObject(USBConnected);
            string filecreationofUSBConnected = "USBConnectedDevices.json";
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofUSBConnected);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(USB_Json.ToString());
                tw.Close();
                //MessageBox.Show("Done with file");
            }
        }
        public void GetAllConnectedDisplays()
        {
            int i = 0;
            ManagementObjectCollection collection;
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> DisplayConnected = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            using (var finddevice = new ManagementObjectSearcher(@"Select * From Win32_DesktopMonitor"))
                collection = finddevice.Get();
            foreach (var device in collection)
            {
                string deviceName = device.GetPropertyValue("Name").ToString();
                string deviceDescription = device.GetPropertyValue("Description").ToString();
                string deviceId = device.GetPropertyValue("PNPDeviceID").ToString();
                DisplayConnected.Add(i.ToString(), new Dictionary<string, Dictionary<string, string>>
                {
                    { deviceId, new Dictionary<string, string>
                    {
                        {deviceName, deviceDescription },
                    } }
                });
                i++;
            }
            string ConnectedDevices_Json = JsonConvert.SerializeObject(DisplayConnected);
            string filecreationofDisplayConnected = "DisplayConnectedDevices.json";
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofDisplayConnected);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(ConnectedDevices_Json.ToString());
                tw.Close();
            }
        }
        public bool GetInternetIsConnectedOrNot()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void GetDeviceConfiguration()
        {
            string email2 = email.Text.ToString();
            DeviceCredentials credentials = new DeviceCredentials();
            string hwclass = "Win32_Processor";
            string hwclass2 = "Win32_VideoController";
            string syntax = "Name";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                credentials.CPUName = Convert.ToString(mj[syntax]);
            }
            ManagementObjectSearcher mos2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass2);
            foreach (ManagementObject mj in mos2.Get())
            {
                credentials.GPUName = Convert.ToString(mj[syntax]);
            }
            string filecreationofgeneral = "DeviceConfiguration.json";

            string JSON_credentials = JsonConvert.SerializeObject(credentials);
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofgeneral);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(JSON_credentials.ToString());
                tw.Close();
            }
        }
        public void GetBatteryPercentage()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_Battery");
            string batterypercentage;
            Dictionary<string, string> batteryy = new Dictionary<string, string>();
            foreach (ManagementObject mo in mos.Get())
            {
                batterypercentage = mo["EstimatedChargeRemaining"].ToString();
                batteryy.Add("Battery Percentage", batterypercentage);
            }
            
            string batterypercentage_Json = JsonConvert.SerializeObject(batteryy);
            string filecreationofDisplayConnected = "Battery_Percentage.json";
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofDisplayConnected);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(batterypercentage_Json.ToString());
                tw.Close();
            }
        }
        public void GetResolution()
        {
            string screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth.ToString();

            string screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight.ToString();


            string resolution = "Resolution : " + screenWidth + " X " + screenHeight;

            MessageBox.Show(resolution);
        }
        public void Filecreation()
        {
            
            GetAllConnectedCameras();
            GetAllConnectedUSBDevices();
            GetAllConnectedDisplays();
            GetDeviceConfiguration();
            GetBatteryPercentage();
            GetResolution();
            bool isConnected = GetInternetIsConnectedOrNot();
            Dictionary<string, bool> InternetIsConnected = new Dictionary<string, bool>();
            InternetIsConnected.Add("InternetConnection", isConnected);
            string InternetConnected_Json = JsonConvert.SerializeObject(InternetIsConnected);
            string filecreationofDisplayConnected = "InternetConnection.json";
            string path3 = @"History\";
            string path4 = System.IO.Path.Combine(path3, filecreationofDisplayConnected);
            using (var tw = new StreamWriter(path4, false))
            {
                tw.WriteLine(InternetConnected_Json.ToString());
                tw.Close();
            }


        }
        private class DeviceCredentials
        {
            public string CPUName { get; set; }
            public string GPUName { get; set; }
        }
        public class Logincredientials
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public static async Task GetFooAsync(string email__, string password__)
        {
            // Start asynchronous operation(s) and return associated task.
            string email_ = email__;
            string password_ = password__;
            Logincredientials newobj = new Logincredientials();
            newobj.Email = email_;
            newobj.Password = password_;
            string JSON_result = JsonConvert.SerializeObject(newobj);
            string json = JSON_result;
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5000/api/user/login";
            //Thread.Sleep(4000);
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            //MessageBox.Show(response.StatusCode.ToString());
            string result = response.Content.ReadAsStringAsync().Result;
            JObject result2 = JObject.Parse(result);
            //MessageBox.Show(result2["Username"].ToString());
            string returingvariable = response.StatusCode.ToString();
            //responsefromhttps = returingvariable;
            //profileimage = result2["image64bit"].ToString();
            //nameofuser = result2["Username"].ToString();
            MessageBox.Show("its Done");

        }
        private async void makeRequest()
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                string email_ = email.Text.ToString();
                string password_ = password.Password.ToString();
                Logincredientials newobj = new Logincredientials();
                newobj.Email = email_;
                newobj.Password = password_;
                string JSON_result = JsonConvert.SerializeObject(newobj);
                string json = JSON_result;
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost:5000/api/user/login";
                //Thread.Sleep(4000);
                var client = new HttpClient();
                var task = Task.Run(() => client.PostAsync(url, data));
                task.Wait();
                var response = task.Result;
                //var response = await client.PostAsync(url, data);
                //MessageBox.Show(response.StatusCode.ToString());
                string result = response.Content.ReadAsStringAsync().Result;
                JObject result2 = JObject.Parse(result);
                //MessageBox.Show(result2["Username"].ToString());
                string returingvariable = response.StatusCode.ToString();
                responsefromhttps = returingvariable;
                if (responsefromhttps == "OK")
                {
                    profileimage = result2["image64bit"].ToString();
                    nameofuser = result2["Username"].ToString();
                }
            }
            else
            {
                MessageBox.Show("There is no internet connection.\n Please make sure that you have an internet connection.", "No Internet");
            }
            //System.Console.WriteLine(result);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string email_ = email.Text.ToString();
            string password_ = password.Password.ToString();
            makeRequest();
            

            if (responsefromhttps == "OK")
            {

                Window6 win6 = new Window6(email_,nameofuser, profileimage);
                win6.Show();
                this.Close();
                SettingWindow settingWindow = new SettingWindow(email_, nameofuser, profileimage, countt);
            }
            else
            {
                
                MessageBox.Show("Invalid Email and Password");
                email.BorderBrush = Brushes.Red;
                email.BorderThickness = new Thickness(1, 1, 1, 1);
                password.BorderBrush = Brushes.Red;
                password.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            /*
            using (StreamReader file = File.OpenText("Signup.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                string email2 = o2["Email"].ToString();
                string password2 = o2["Password"].ToString();
                if (email_ == email2)
                {
                    email.BorderBrush = Brushes.Gray;
                    email.BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5);
                    if (password_ == password2)
                    {
                        email.BorderBrush = Brushes.Gray;
                        email.BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5);
                        Window6 win6 = new Window6();
                        win6.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password");
                        password.BorderBrush = Brushes.Red;
                        password.BorderThickness = new Thickness(1, 1, 1, 1);
                    }
                }
                else
                {
                    if (password_ != password2)
                    {
                        MessageBox.Show("Invalid Email and Password");
                        email.BorderBrush = Brushes.Red;
                        email.BorderThickness = new Thickness(1, 1, 1, 1);
                        password.BorderBrush = Brushes.Red;
                        password.BorderThickness = new Thickness(1, 1, 1, 1);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email");
                        email.BorderBrush = Brushes.Red;
                        email.BorderThickness = new Thickness(1, 1, 1, 1);
                        password.BorderBrush = Brushes.Gray;
                        password.BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5);

                    }
                }
            }
            
            */

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }
    }
}
