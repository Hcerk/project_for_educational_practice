using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Project_for_educational_practice.Scripts;

namespace Project_for_educational_practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = 100;
                int b = 0;
                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException er)
            {
                new Logger().WriteInLog(LogType.Error, $"Ошибка - {er.Message}");
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new Logger().WriteInLog(LogType.Warning, "Предупреждение о выходе из программы");
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
            else
                e.Cancel = true;
        }
    }
}
