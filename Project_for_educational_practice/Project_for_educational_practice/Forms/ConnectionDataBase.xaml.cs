using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Project_for_educational_practice.Forms.Database;

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

        public void Exit(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Mask.Visibility = Visibility.Hidden;
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void LoadedControl(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            if (mysql.IsChecked.Value)
                main.Children.Add(new mysql());
            else
                main.Children.Add(new msServer());
        }
    }
}
