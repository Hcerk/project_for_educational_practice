using System.Windows;
using Microsoft.Win32;

using LoggerDLL;

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

        public void Exit(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }
        
        public void OpenBtt(object sender, RoutedEventArgs e)
        {
            bool? myDres = new OpenFileDialog().ShowDialog();
            if (myDres == true | myDres == false)
                new Logger().WriteInLog(LogType.Error, "Невозможно открыть файл");
        }

        public void ExitBtt(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }

        public void OpenSettings(object sender, RoutedEventArgs e) { new Forms.Settings().ShowDialog(); }
        
        public void ClearPamel(object sender, RoutedEventArgs e) { Panel.Children.Clear(); }

        public void Info(object sender, RoutedEventArgs e) { new Forms.InfoPanel().ShowDialog(); }

    }
}
