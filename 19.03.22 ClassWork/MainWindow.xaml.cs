using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace _19._03._22_ClassWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebRequest request = WebRequest.Create("https://yandex.ru/");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string site = reader.ReadToEnd();

            int index = site.IndexOf("weather__content");
            if(index != -1)
            {
                site = site.Remove(0, index);
            }

            index = site.IndexOf("label=");
            if (index != -1)
            {
                site = site.Remove(0, index + 7);
            }

            index = site.IndexOf("\"");
            if (index != -1)
            {
                site = site.Remove(index);
            }
            RTB.AppendText(site);
        }
    }
}
