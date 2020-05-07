using System;
using System.Windows.Media.Imaging;

namespace PictureDLL
{
    public class Picture
    {
        public BitmapImage PictureFile(string path) { return (new BitmapImage(new Uri(path))); }
    }
}
