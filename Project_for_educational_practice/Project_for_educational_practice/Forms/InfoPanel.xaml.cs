using System.Reflection;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Project_for_educational_practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для InfoPanel.xaml
    /// </summary>
    public partial class InfoPanel : Window
    {
        public InfoPanel()
        {
            InitializeComponent();

            VersionApp.Text = "Версия программы - " +  Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void hClick(object sender, RoutedEventArgs e) { Process.Start("https://github.com/Hcerk/project_for_educational_practice/"); }

        private void CloseBtt(object sender, RoutedEventArgs e) { this.Close(); }

        private void MoveWindow(object sender, MouseButtonEventArgs e) { this.DragMove(); }

    }
}
