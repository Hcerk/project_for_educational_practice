using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using LoggerDLL;

namespace Project_for_educational_practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для ConnectionDataBase.xaml
    /// </summary>
    public partial class ConnectionDataBase : Window
    {
        public ConnectionDataBase()
        {
            InitializeComponent();
            new Logger().WriteInLog(LogType.Info, "Открытие настройки базы данных");
        }

        private void BMouseEnter(object sender, MouseEventArgs e) => ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(255, 201, 94));

        private void BMouseLeave(object sender, MouseEventArgs e) => ((Button)sender).Background = new SolidColorBrush(Colors.Transparent);

        public void Exit(object sender, RoutedEventArgs e) => Close();

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();
    }
}
