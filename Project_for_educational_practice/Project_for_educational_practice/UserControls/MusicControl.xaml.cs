using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Project_for_educational_practice.Scripts;

using MusicDLL;
using System;

namespace Project_for_educational_practice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MusicControl.xaml
    /// </summary>
    public partial class MusicControl : UserControl
    {
        MediaPlayer player;
        public MusicControl()
        {
            InitializeComponent();
            player = music.GetPlayer();
        }

        Music music = new Music();

        private void PlayPlayer(object sender, MouseButtonEventArgs e)
        {
            if (music.Position > new TimeSpan(0, 0, 0))
                music.Play();
            else
            {
                music.Open(Data.PathFile);
                music.Play();
            }
        }
        private void PausePlayer(object sender, MouseButtonEventArgs e) => music.Pause();
        private void StopPlayer(object sender, MouseButtonEventArgs e) => music.Stop();

        private void MusicLoaded(object sender, RoutedEventArgs e)
        {

            Volume.Value = player.Volume * 100;

            Volume.ValueChanged += (send, err) => music.Volume = Volume.Value / 100;

            player.MediaOpened += (send, err) => NameMusic.Text = music.GetNameMusic();

            player.MediaEnded += (send, err) => NameMusic.Text = "";

        }

        private void MusicUnloaded(object sender, RoutedEventArgs e) => music.Stop();
    }
}
