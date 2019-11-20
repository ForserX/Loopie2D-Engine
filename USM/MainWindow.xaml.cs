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

namespace USM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string cfg, userdata, scripts, images, snd;
        private static readonly INIManager IFS = new INIManager(@"../setting.ini");
        private static readonly string WorkDir = System.IO.Directory.GetCurrentDirectory();

        public MainWindow()
        {
            InitializeComponent();
            
            /// CFG setter
            cfg      = IFS.GetString("global", "config");
            userdata = IFS.GetString("global", "user");
            scripts  = IFS.GetString("global", "scripts");
            images   = IFS.GetString("global", "img");
            snd      = IFS.GetString("global", "SoundActive");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.IO.File.Exists(WorkDir + "/" + images + BackImageTextBox.Text))
            {
                BitmapImage BMap = new BitmapImage
                    (
                        new Uri(string.Format(WorkDir + "/" + images + BackImageTextBox.Text), 
                        UriKind.Relative)
                    );
                BMap.Freeze();

                ImgBox.Source = BMap;
                ImgBox.Stretch = Stretch.Fill;
            }
            //D:\канцеляр2019\Новая папка\code\Loopie2D-Engine\data\images\backgrounds\dawn.jpg
        }
    }
}
