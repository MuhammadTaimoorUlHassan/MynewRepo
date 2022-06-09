using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using File = System.IO.File;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Windows.Media;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace LoginFenris
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public string imagepath;
        public string roleofstriker2;
        public string handedness2;
        public string gender;
        public int emailfound = 0;
        public List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            MessageBox.Show(cultureList.ToString());
            return cultureList;
        }
        public List<string> GetAllCountrysNames()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            return cultures
                    .Select(cult => (new RegionInfo(cult.LCID)).DisplayName)
                    .Distinct()
                    .OrderBy(q => q)
                    .ToList();
        }
        
        private void PopulateCountryComboBox()
        {
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            List<string> countryNames = new List<string>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(country.DisplayName.ToString());
                //MessageBox.Show(country.DisplayName.ToString());
            }
            IEnumerable<string> nameAdded = countryNames.OrderBy(names => names).Distinct();
            //MessageBox.Show(nameAdded.ToString());
            foreach (string item in nameAdded)
            {
                //MessageBox.Show(item);
                
                country_.Items.Add(item);
            }
        }
        public Window4(string roleofstriker_, string handedness_)
        {
            
            
            InitializeComponent();
            roleofstriker2 = roleofstriker_;
            handedness2 = handedness_;
            if(roleofstriker2 == "Striker")
            {
                role_.SelectedIndex = 1;
            }
            else
            {
                role_.SelectedIndex = 2;
            }
            role_.SelectedIndex = 0;
            if(handedness_ == "Right Hand")
            {
                righthandbtn.IsChecked = true;
            }
            else
            {
                lefthandbtn.IsChecked = true;
            }
            //PopulateCountryComboBox();
            country_.ItemsSource = GetAllCountrysNames();
            country_.ItemsSource = GetCountryList();
            
            //Headersettings();
        }
        
        

        
        public void Headersettings()
        {
            string base64String;
            using (StreamReader file = File.OpenText("Signup.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                
                base64String = o2["image64bit"].ToString();

            }
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            

            
        }
        private void role__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fullPath;
            BitmapImage image;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(op.FileName));
                fullPath = op.FileName;
                newimagee.Source = image;
                imagepath = op.FileName;
                
            }
            using (System.Drawing.Image image2 = System.Drawing.Image.FromFile(imagepath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image2.Save(m, image2.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    imagepath = Convert.ToBase64String(imageBytes);
                    
                   
                }
            }
        }
        class Signup_Data
        {
            public string Username { get; set; }
            public string image64bit { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Phone_number { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zip_code { get; set; }
            public string Country { get; set; }
            public string Role { get; set; }
            public string Gender {get; set;}
            public string Handedness { get; set; }
        }

        private static HttpClient _httpClient = new HttpClient();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            string username = username_.Text.ToString();
            string email = email_.Text.ToString();
            string phonenumber = phonenumber_.Text.ToString();

            string street = street_.Text.ToString();
            string city = city_.Text.ToString();
            string zipcode = zipcode_.Text.ToString();
            string country = country_.Text.ToString();
            string role = role_.Text.ToString();
            string password = password_.Password.ToString();
            username_.BorderThickness = new Thickness(0,0, 0, 0);
            email_.BorderThickness = new Thickness(0,0, 0, 0);
            phonenumber_.BorderThickness = new Thickness(0,0, 0, 0);
            street_.BorderThickness  = new Thickness (0,0, 0, 0);
            city_.BorderThickness = new Thickness (0,0, 0, 0);
            zipcode_.BorderThickness = new Thickness (0,0, 0, 0);
            country_.BorderThickness = new Thickness (0,0, 0, 0);
            password_.BorderThickness = new Thickness (0,0, 0, 0);
            retypepassword_.BorderThickness = new Thickness(0,0, 0, 0);
            uploadpic_.BorderThickness = new Thickness(0,0, 0, 0);
            if(username == "")
            {
                counter++;
                username_.BorderBrush = Brushes.Red;
                username_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (email == "")
            {
                counter++;
                email_.BorderBrush = Brushes.Red;
                email_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (phonenumber == "")
            {
                counter++;
                phonenumber_.BorderBrush = Brushes.Red;
                phonenumber_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (street == "")
            {
                counter++;
                street_.BorderBrush = Brushes.Red;
                street_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (city == "")
            {
                counter++;
                city_.BorderBrush = Brushes.Red;
                city_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (zipcode == "")
            {
                counter++;
                zipcode_.BorderBrush = Brushes.Red;
                zipcode_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (country == "")
            {
                counter++;
                country_.BorderBrush = Brushes.Red;
                country_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if (password == "" || password.Length <=5)
            {
                counter++;
                password_.BorderBrush = Brushes.Red;
                password_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            if(imagepath == "")
            {
                counter++;
                uploadpic_.BorderBrush = Brushes.Red;
                uploadpic_.BorderThickness = new Thickness(1,1, 1, 1);
            }
            if (counter == 0)
            {
                Signup_Data newobj = new Signup_Data();
                newobj.Username = username;
                newobj.image64bit = imagepath;
                newobj.Password = password;
                newobj.Email = email;
                newobj.Phone_number = phonenumber;
                newobj.Street = street;
                newobj.City = city;
                newobj.Zip_code = zipcode;
                newobj.Country = country;
                newobj.Role = role;
                newobj.Gender = gender;
                newobj.Handedness = handedness2;

                String json = Newtonsoft.Json.JsonConvert.SerializeObject(newobj);
                string JSON_result = JsonConvert.SerializeObject(newobj);
                makeRequest(JSON_result);


                string filecreation = "Signup9.json";

                using (var tw = new StreamWriter(filecreation, false))
                {
                    tw.WriteLine(JSON_result.ToString());
                    tw.Close();
                }
                



                Thread.Sleep(4000);
                //MessageBox.Show("After Sleep");
                if (emailfound == 0)
                {
                    int countt = 1;
                    
                    
                    //settingWindow.Show();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields");
            }
        }
        public async void makeRequest(string JSON_result)
        {
            //MessageBox.Show(JSON_result.ToString());
            string json = JSON_result;
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5000/api/user/signup";
            var client = new HttpClient();
            
            var response = await client.PostAsync(url, data);
           // Thread.Sleep(9000);
            string result = response.Content.ReadAsStringAsync().Result;
            string returingvariable = response.StatusCode.ToString();
            if (returingvariable == "422")
            {
                emailfound = 1;
                //MessageBox.Show(returingvariable);
                MessageBox.Show("Email already exists");
                email_.BorderBrush = Brushes.Red;
                email_.BorderThickness = new Thickness(1, 1, 1, 1);
            }
            else
            {
                emailfound = 0;
            }
            //MessageBox.Show(result);
            //System.Console.WriteLine(result);
            
        
        }

        

        private void female__Checked(object sender, RoutedEventArgs e)
        {
            gender = female_.Content.ToString();
        }

        private void male__Checked(object sender, RoutedEventArgs e)
        {
            gender = male_.Content.ToString();
        }

        private void righthandbtn_Checked(object sender, RoutedEventArgs e)
        {
            handedness2 = righthandbtn.Content.ToString();
        }

        private void lefthandbtn_Checked(object sender, RoutedEventArgs e)
        {
            handedness2 = lefthandbtn.Content.ToString();
        }

        private void country__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LaunchMoniter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
