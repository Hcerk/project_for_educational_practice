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

namespace Project_for_educational_practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int index = 0;
        private static string[] files = { "/GIF/1.mp4", "/GIF/2.mp4", "/GIF/3.mp4" };
        MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MP3
            player.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/MP3/Dog-El Dembow del Perro-kissvk.com.mp3", UriKind.Absolute));
            player.Volume = 1;
            player.Play();
            // GIF
            mElement.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + files[index], UriKind.Absolute);
            mElement.UnloadedBehavior = MediaState.Manual;
            mElement.MediaEnded += (send, err) =>
            {
                index = files.Length - 1 > index++ ? index++ : 0;
                mElement.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + files[index], UriKind.Absolute);
                mElement.Position = new TimeSpan(0, 0, 0);
                mElement.Play();
            };
            mElement.MediaOpened += (send, err) => { optimazed(); };
        }

        private void optimazed(int H = 35)
        {
            this.Width = mElement.Width;
            this.MaxWidth = mElement.Width;
            this.MinWidth = mElement.Width;
            this.Height = mElement.Height + H;
            this.MaxHeight = mElement.Height + H;
            this.MinHeight = mElement.Height + H;
            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = (SystemParameters.WorkArea.Height - this.Height) / 2;
        }
    }
}
