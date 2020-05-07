using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using Project_for_educational_practice.Scripts;

using PictureDLL;

namespace Project_for_educational_practice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PictureControl.xaml
    /// </summary>
    public partial class PictureControl : UserControl
    {
        public PictureControl() => InitializeComponent();

        private void PictureLoaded(object sender, RoutedEventArgs e) => imageMain.Source = new Picture().PictureFile(Data.PathFile);
    }
}
