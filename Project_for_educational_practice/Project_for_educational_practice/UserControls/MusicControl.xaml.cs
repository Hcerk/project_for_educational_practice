using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Project_for_educational_practice.Scripts;

using MusicDLL;
using System;
using System.Threading;
using Org.BouncyCastle.Asn1.Cms;

namespace Project_for_educational_practice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MusicControl.xaml
    /// </summary>
    public partial class MusicControl : UserControl
    {
        MediaPlayer player;
        Timer timer;

        public MusicControl()
        {
            InitializeComponent();
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
            player = music.GetPlayer();

            Volume.Value = player.Volume * 100;

            Volume.ValueChanged += (send, err) => music.Volume = Volume.Value / 100;

            player.MediaOpened += (send, err) =>
            {
                NameMusic.Text = music.GetNameMusic();
                progressBar.Minimum = 0;
                progressBar.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
                currentTimePlayMusic.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;

                endTime.Text = player.NaturalDuration.TimeSpan.Minutes.ToString() + ":" + player.NaturalDuration.TimeSpan.Seconds.ToString();
            };

            player.MediaEnded += (send, err) => NameMusic.Text = "";

            timer = new Timer(new TimerCallback((object state) =>
            {
                Dispatcher.Invoke(() => 
                {
                    progressBar.Value = player.Position.TotalSeconds;
                    currentTime.Text = player.Position.Minutes.ToString() + ":" + player.Position.Seconds.ToString();
                });
            }), null, 0, 100);

        }

        private void MusicUnloaded(object sender, RoutedEventArgs e)
        {
            music.Stop();
            timer.Dispose();
        }

        private void LeafMusic(object sender, MouseButtonEventArgs e)
        {
            player.Position = new TimeSpan(0, 0, Convert.ToInt32(currentTimePlayMusic.Value));
        }
    }
}
