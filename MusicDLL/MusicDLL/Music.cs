using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicDLL
{
    public interface MusicTemplate
    {
        void Open(string path);

        void Play();
        void Pause();
        void Stop();

        string GetNameMusic();

        MediaPlayer GetPlayer();

    }

    public class Music : MusicTemplate
    {
        static string pathFile;
        static MediaPlayer player;

        public Music() => player = new MediaPlayer();

        public double Volume
        {
            get { return player.Volume; }
            set { player.Volume = value; }
        }
        public TimeSpan Position 
        { 
            get { return player.Position; }
            set { player.Position = value; }
        }

        public string GetNameMusic()
        {
            return (new FileInfo(pathFile).Name).Split('.')[0];
        }

        public MediaPlayer GetPlayer() { return player; }

        public void Open(string path)
        {
            pathFile = path;
            player.Open(new Uri(path));
        }

        public void Pause() => player.Pause();

        public void Play() => player.Play();

        public void Stop() => player.Stop();

    }
}
