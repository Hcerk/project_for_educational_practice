using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Project_for_educational_practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Logs.xaml
    /// </summary>
    public partial class Logs : Window
    {
        private Timer timer;

        public Logs() => InitializeComponent();

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        public void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
            timer.Dispose();
        }

        private void BMouseEnter(object sender, MouseEventArgs e) => ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(255, 201, 94));

        private void BMouseLeave(object sender, MouseEventArgs e) => ((Button)sender).Background = new SolidColorBrush(Colors.Transparent);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new Timer(new TimerCallback((object state) =>
            {
                StreamReader f = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                Dispatcher.Invoke(() =>
                {
                    loggerData.Children.Clear();
                    string line;
                    while ((line = f.ReadLine()) != null)
                        loggerData.Children.Insert(0, new TextBlock { Margin = new Thickness(10, 0, 0, 0), Text = line });
                });
                f.Close();
            }
            ), null, 0, 500);
        }
    }
}
