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
    /// Interaction logic for History_Screen_1.xaml
    /// </summary>
    public partial class History_Screen_1 : Window
    {
        public History_Screen_1()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int day1 = -1;
            int month1 = -1;
            int year1 = -1;
            int date1 = 20221231;

            int day2 = -1;
            int month2 = -1;
            int year2 = -1;
            int date2 = -1;

            string filter1 = DatePicker1.Text;
            //extracting date from string to numbers
            if (filter1[1] == '/' && filter1[3] == '/')
            {
                month1 = filter1[0] - '0';
                day1 = filter1[2] - '0';
                year1 = filter1[4] - '0';
                year1 = year1 * 10;
                year1 = year1 + (filter1[5] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[6] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[7] - '0');
            }
            else if (filter1[1] == '/' && filter1[4] == '/')
            {
                month1 = filter1[0] - '0';
                day1 = filter1[2] - '0';
                day1 = day1 * 10;
                day1 = day1 + (filter1[3] - '0');
                year1 = filter1[5] - '0';
                year1 = year1 * 10;
                year1 = year1 + (filter1[6] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[7] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[8] - '0');
            }
            else if (filter1[2] == '/' && filter1[4] == '/')
            {
                month1 = filter1[0] - '0';
                month1 = month1 * 10;
                month1 = month1 + (filter1[1] - '0');
                day1 = filter1[3] - '0';
                year1 = filter1[5] - '0';
                year1 = year1 * 10;
                year1 = year1 + (filter1[6] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[7] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[8] - '0');
            }
            else if (filter1[2] == '/' && filter1[5] == '/')
            {
                month1 = filter1[0] - '0';
                month1 = month1 * 10;
                month1 = month1 + (filter1[1] - '0');
                day1 = filter1[3] - '0';
                day1 = day1 * 10;
                day1 = day1 + (filter1[4] - '0');
                year1 = filter1[6] - '0';
                year1 = year1 * 10;
                year1 = year1 + (filter1[7] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[8] - '0');
                year1 = year1 * 10;
                year1 = year1 + (filter1[9] - '0');
            }
            date1 = (year1 * 100) + month1;
            date1 = (date1 * 100) + day1;




            string filter2 = DatePicker2.Text;
            //extracting date from string to numbers
            if (filter2[1] == '/' && filter2[3] == '/')
            {
                month2 = filter2[0] - '0';
                day2 = filter2[2] - '0';
                year2 = filter2[4] - '0';
                year2 = year2 * 10;
                year2 = year2 + (filter2[5] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[6] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[7] - '0');
            }
            else if (filter2[1] == '/' && filter2[4] == '/')
            {
                month2 = filter2[0] - '0';
                day2 = filter2[2] - '0';
                day2 = day2 * 10;
                day2 = day2 + (filter2[3] - '0');
                year2 = filter2[5] - '0';
                year2 = year2 * 10;
                year2 = year2 + (filter2[6] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[7] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[8] - '0');
            }
            else if (filter2[2] == '/' && filter2[4] == '/')
            {
                month2 = filter2[0] - '0';
                month2 = month2 * 10;
                month2 = month2 + (filter2[1] - '0');
                day2 = filter2[3] - '0';
                year2 = filter2[5] - '0';
                year2 = year2 * 10;
                year2 = year2 + (filter2[6] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[7] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[8] - '0');
            }
            else if (filter2[2] == '/' && filter2[5] == '/')
            {
                month2 = filter2[0] - '0';
                month2 = month2 * 10;
                month2 = month2 + (filter2[1] - '0');
                day2 = filter2[3] - '0';
                day2 = day2 * 10;
                day2 = day2 + (filter2[4] - '0');
                year2 = filter2[6] - '0';
                year2 = year2 * 10;
                year2 = year2 + (filter2[7] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[8] - '0');
                year2 = year2 * 10;
                year2 = year2 + (filter2[9] - '0');
            }
            date2 = (year2 * 100) + month2;
            date2 = (date2 * 100) + day2;
            History_Screen2 history_Screen2 = new History_Screen2(date1, date2);
            history_Screen2.Show();
            this.Hide();
        }
    }
}
