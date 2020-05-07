using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System;

using Project_for_educational_practice.Scripts;
using Project_for_educational_practice.UserControls;

using LoggerDLL;

namespace Project_for_educational_practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog dialog = new OpenFileDialog();

        public MainWindow() => InitializeComponent();

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        public void TurningBtt(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        public void Exit(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void BMouseEnter(object sender, MouseEventArgs e) =>  ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(255, 201, 94));

        private void BMouseLeave(object sender, MouseEventArgs e) => ((Button)sender).Background = new SolidColorBrush(Colors.Transparent);

        public void OpenBtt(object sender, RoutedEventArgs e)
        {
            dialog.Filter = "Text files(*.txt;*.1)|*.txt;*.1|" +
                            "Music files(*.mp3)|*.mp3|" +
                            "Photo files(*.png;*.jpg)|*.png;*.jpg";
            dialog.FileOk += (sen, err) => 
            {
                new Logger().WriteInLog(LogType.Info, "Открываем файл - " + dialog.FileName);
                Data.PathFile = dialog.FileName;
                string expansion = dialog.FileName.Split('.')[dialog.FileName.Split('.').Length - 1];
                Panel.Children.Clear();
                if (expansion == "txt" | expansion == "1")
                    Panel.Children.Add(new TextControl());
                else if (expansion == "mp3")
                    Panel.Children.Add(new MusicControl());
                else if (expansion == "png" | expansion == "jpg")
                    Panel.Children.Add(new PictureControl());
            };
            dialog.ShowDialog();
        }

        public void ConnectionDataBase(object sender, RoutedEventArgs e) => new Forms.ConnectionDataBase().ShowDialog();

        public void OpenSettings(object sender, RoutedEventArgs e) => new Forms.Settings().ShowDialog(); 
        
        public void ClearPamel(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            new Logger().WriteInLog(LogType.Info, "Очистка панели");
        }

        public void Info(object sender, RoutedEventArgs e) => new Forms.InfoPanel().Show();

        public void OpenLogs(object sender, RoutedEventArgs e) => new Forms.Logs().Show();

    }
}
