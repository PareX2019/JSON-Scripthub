/* 
 COPYRIGHT 2020-2021
If you are planing to use this in your own exploit/program 
then please give credits to PareX

This program was created by PareX
*/

using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyJSON_Scripthub
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

        private readonly string jsonLink = "https://oxygenu.xyz/OxygenU/scripthub.json";//json file raw link like pastebin or something
        //Oxygen u ones for example ^ (its from oxygen u because i am a developer for oxygen u)

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pic.Stretch = System.Windows.Media.Stretch.Fill;
            var json_object = JObject.Parse(new WebClient().DownloadString(jsonLink))["scriptHub"];//gets the json object out of the link
            foreach (JToken sub_object in json_object.Children())//loops for each object in the json file and adds their to the listbox
                listbox.Items.Add($"{json_object[sub_object.ToObject<JProperty>().Name]["Name"]}");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var json_object = JObject.Parse(new WebClient().DownloadString(jsonLink))["scriptHub"];
            foreach (JToken sub_object in json_object.Children())//loops for each object in the json file and converts them into json tokens which can be used to acess their data such as Name, Description etc.
            {
                if (json_object[sub_object.ToObject<JProperty>().Name]["Name"].ToString() == listbox.SelectedItem.ToString())
                {
                    desc.Text = json_object[sub_object.ToObject<JProperty>().Name]["Description"].ToString();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@json_object[sub_object.ToObject<JProperty>().Name]["Picture"].ToString(), UriKind.Absolute);
                    bitmap.EndInit();
                    pic.Source = bitmap;//converts the image to bitmap image so the picture box can accept it
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem is null) return;
            var json_object = JObject.Parse(new WebClient().DownloadString(jsonLink))["scriptHub"];
            foreach (JToken sub_object in json_object.Children())
            {
                if (json_object[sub_object.ToObject<JProperty>().Name]["Name"].ToString() == listbox.SelectedItem.ToString())//loops like the above ^ and checks if the selected listbbox item is the one the loop hit and if it is it will execute it.
                {
                  /*Execute(new WebClient().DownloadString(json_object[sub_object.ToObject<JProperty>().Name]["source"].ToString())); 
                   Your execution function goes above ^ */
                }

            }
        }
    }
}
