using System.Windows;
using System.Windows.Controls;

using Project_for_educational_practice.Scripts;
using Project_for_educational_practice.UserControls;

using DataBaseDLL;
using System;
using LoggerDLL;

namespace Project_for_educational_practice.Forms.Database
{
    /// <summary>
    /// Логика взаимодействия для mysql.xaml
    /// </summary>
    public partial class mysql : UserControl
    {
        public mysql()
        {
            InitializeComponent();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (TextBox control in new TextBox[] { server, database, uid, password })
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        MessageBox.Show("Заполните поля - Data Source, Initial Catalog", "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                string dataSourceStirng = "Server=" + server.Text + ";Database=" + database.Text + ";User Id=" + uid.Text + ";password=" + password.Text;
                if (!string.IsNullOrEmpty(port.Text))
                    dataSourceStirng += ";port=" + port.Text;
                Data.connectMySQL = new MySQL(dataSourceStirng);
                ((MainWindow)Application.Current.MainWindow).Panel.Children.Add(new database());
                ((MainWindow)Application.Current.MainWindow).Mask.Visibility = Visibility.Hidden;
                ((ConnectionDataBase)((Grid)((Border)((Grid)((Grid)((Grid)Parent).Parent).Parent).Parent).Parent).Parent).Close();
            }
            catch (Exception er)
            {
                new Logger().WriteInLog(LogType.Error, er.Message);
                MessageBox.Show("Ошибка записана в логи", "Ошибка в подключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
