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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string GetDataFromWeb()
        {
            string URL = "http://meteo.gig.eu/";
            string file = @"C:\Users\krupo\OneDrive\Pulpit\Weather-station-\WeatherApp\WeatherApp\html.txt";
            WebClient client = new WebClient();
            Stream data = client.OpenRead(URL);
            StreamReader reader = new StreamReader(data);

            string htmlCode = reader.ReadToEnd();

            data.Close();
            reader.Close();
            File.WriteAllText(file, htmlCode);
            return TrimHTML(htmlCode, "µg/m³<br/>Temperatura: ", "°C<br/>Wilgotność");
        }

        public static string TrimHTML(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }


        public void FillTextBox()
        {
            string trimmedHTML = GetDataFromWeb();
            string file = @"C:\Users\krupo\OneDrive\Pulpit\Weather-station-\WeatherApp\WeatherApp\debug.txt";
            File.WriteAllText(file, trimmedHTML);
            TemperatureBox.Text = trimmedHTML.ToString();
            ConditionBox.Text = "Sunny";
        }



        private void Update_Click(object sender, RoutedEventArgs e)
        {
            FillTextBox();
        }

        private void ConditionBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
