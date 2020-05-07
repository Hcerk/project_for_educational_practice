using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Project_for_educational_practice.Scripts;

using TextDLL;
using LoggerDLL;

namespace Project_for_educational_practice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TextControl.xaml
    /// </summary>
    public partial class TextControl : UserControl
    {
        public TextControl() => InitializeComponent();

        private void ContentTextLoaded(object sender, RoutedEventArgs e) => ContentText.Text = new Text().Read(Data.PathFile);


        private void SaveData(object sender, RoutedEventArgs e) => new Text().Write(Data.PathFile, ContentText.Text);

        private void Close(object sender, RoutedEventArgs e)
        {
            new Logger().WriteInLog(LogType.Info, "Закрытие файла - " + Data.PathFile);
            ((Grid)this.Parent).Children.Clear();
            Data.PathFile = "";
        }

        private void ContentTextKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ContentText.Text += "\n";
                ContentText.CaretIndex = ContentText.Text.Length;
            }
        }
    }
}
