using System.Windows;
using System.Windows.Controls;

using Project_for_educational_practice.Scripts;
using Project_for_educational_practice.UserControls;

using DataBaseDLL;

namespace Project_for_educational_practice.Forms.Database
{
    /// <summary>
    /// Логика взаимодействия для msServer.xaml
    /// </summary>
    public partial class msServer : UserControl
    {

        public msServer()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            foreach (TextBox control in new TextBox[] { source, catalog })
                if (string.IsNullOrEmpty(control.Text))
                {
                    MessageBox.Show("Заполните поля - Data Source, Initial Catalog", "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            string dataSourceStirng = "Data Source=" + source.Text + ";Initial Catalog=" + catalog.Text + ";Persist Security Info=True;";
            if (!string.IsNullOrEmpty(uid.Text))
                dataSourceStirng += "User ID=" + uid.Text + ";Password=" + password.Text + ";";
            else
                dataSourceStirng += "Integrated Security=SSPI;";
            Data.conncetMS = new MSServer(dataSourceStirng);
            ((MainWindow)Application.Current.MainWindow).Panel.Children.Add(new database());
            ((MainWindow)Application.Current.MainWindow).Mask.Visibility = Visibility.Hidden;
            ((ConnectionDataBase)((Grid)((Border)((Grid)((Grid)((Grid)Parent).Parent).Parent).Parent).Parent).Parent).Close();
        }
    }
}
