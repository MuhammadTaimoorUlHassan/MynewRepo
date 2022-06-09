using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for History_Screen2.xaml
    /// </summary>
    
    public partial class History_Screen2 : Window
    {
        System.Windows.Controls.Button dynamic_buttons;
        System.Windows.Controls.Button buttons_content;
        string path = @"C:\GitHub\Motion2Coach-Desktop\History\";
        string[] fileEntries;
        BitmapImage btm = new BitmapImage(new Uri("thumbnail.png", UriKind.Relative));
        int counter = 0;

        public History_Screen2(int date1, int date2)
        {
            InitializeComponent();
            showRecordings(date1, date2);
        }

        void showRecordings(int date1, int date2)
        {
            fileEntries = Directory.GetDirectories(path);
            int no_of_folders = fileEntries.Length;
            //LB_Counter.Content = no_of_folders; 
            BitmapImage btm = new BitmapImage(new Uri("thumbnail.png", UriKind.Relative));
            int i = 0;
            int row = 1;
            int col = 0;

            while (i < no_of_folders)
            {
                string current_file = System.IO.Path.GetFileName(fileEntries[i]);
                int current_day = current_file[0] - '0';
                current_day = current_day * 10;
                current_day = current_day + current_file[1] - '0';
                int current_month = current_file[3] - '0';
                current_month = current_month * 10;
                current_month = current_month + current_file[4] - '0';

                int current_year = current_file[6] - '0';
                current_year = current_year * 10;
                current_year = current_year + current_file[7] - '0';
                current_year = current_year * 10;
                current_year = current_year + current_file[8] - '0';
                current_year = current_year * 10;
                current_year = current_year + current_file[9] - '0';
                int current_date = (current_year * 10000) + (current_month * 100) + current_day;
                if ((current_date >= date1) && (current_date <= date2))
                {
                    /*
                    dynamic_buttons = new System.Windows.Controls.Button();
                    dynamic_buttons.Content = System.IO.Path.GetFileName(fileEntries[i]);
                    //dynamic_buttons.Click += new RoutedEventHandler(button_Click);
                    this.Grid1.Children.Add(dynamic_buttons);
                    i++;
                    */
                    dynamic_buttons = new Button();

                    ColumnDefinition gridCol1 = new ColumnDefinition();
                    RowDefinition gridRow1 = new RowDefinition();

                    Grid1.ColumnDefinitions.Add(gridCol1);
                    Grid1.RowDefinitions.Add(gridRow1);

                    Image img = new Image();
                    img.Source = btm;
                    img.Stretch = Stretch.Uniform;
                    dynamic_buttons.Content = img;
                    dynamic_buttons.Width = 100;
                    dynamic_buttons.Height = 38;
                    gridRow1.Height = new GridLength(55);
                    Grid.SetRow(dynamic_buttons, row);
                    Grid.SetColumn(dynamic_buttons, col++);

                    Grid1.Children.Add(dynamic_buttons);

                    buttons_content = new Button();
                    buttons_content.Content = System.IO.Path.GetFileName(fileEntries[i]);
                    buttons_content.Width = 100;
                    buttons_content.Height = 38;
                    gridRow1.Height = new GridLength(55);
                    buttons_content.BorderThickness = new Thickness(0);
                    Grid.SetRow(buttons_content, row++);
                    Grid.SetColumn(buttons_content, col--);
                    Grid1.Children.Add(buttons_content);
                    counter++;
                    buttons_content.Click += new RoutedEventHandler(button_Click);

                }
                i++;
            }
            //LB_Counter.Content = counter;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {

            buttons_content = sender as Button;
            dynamic_buttons = new Button();

            //ColumnDefinition gridCol1 = new ColumnDefinition();
            //RowDefinition gridRow1 = new RowDefinition();

            //Grid1.ColumnDefinitions.Add(gridCol1);
            //Grid1.RowDefinitions.Add(gridRow1);

            Image img = new Image();
            img.Source = btm;
            img.Stretch = Stretch.Uniform;
            dynamic_buttons.Content = img;
            dynamic_buttons.Width = 100;
            dynamic_buttons.Height = 38;
            //gridRow1.Height = new GridLength(55);
            //Grid.SetRow(dynamic_buttons, row);
            //Grid.SetColumn(dynamic_buttons, col++);

            Grid1.Children.Add(dynamic_buttons);

            //History_Screen_2 history_Screen_2 = new History_Screen_2(path, (string)buttons_content.Content);
            //history_Screen_2.Show();
            //Window2 window2 = new Window2(path, (string)buttons_content.Content);
            //window2.Show();
        }

    }
}
