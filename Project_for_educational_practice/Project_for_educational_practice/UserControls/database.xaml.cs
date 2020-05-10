using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using LoggerDLL;
using Project_for_educational_practice.Scripts;

namespace Project_for_educational_practice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для database.xaml
    /// </summary>
    public partial class database : UserControl
    {
        public database()
        {
            InitializeComponent();
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            //Data.connect.ToString().Contains("MySQL")
            

            if (query.Text.Length == 0)
                MessageBox.Show("Нулевой запрос");
            else
            {
               try
                {
                    table.Children.Clear();
                    DataGrid dg = new DataGrid { CanUserAddRows = false, CanUserReorderColumns = false };
                    if (Data.conncetMS != null)
                    {
                        if (query.Text.ToLower().Contains("select"))
                        {
                            string[] nameColumns = Data.conncetMS.GetName(query.Text);
                            for (int i = 0; i < nameColumns.Length; i++)
                                dg.Columns.Add(new DataGridTextColumn { Header = nameColumns[i], CanUserResize = false, Binding = new Binding(string.Format("[{0}]", i)) });
                            table.Children.Add(dg);
                            List<string[]> list = Data.conncetMS.Select(query.Text);
                            //
                            // i - строка
                            // j - столбец
                            // 3 - Погрешность
                            //
                            for (int i = 0; i < list.Count; i++)
                            {
                                for (int j = 0; j < list[i].Length; j++)
                                    if (list[i][j].Length > ((string)dg.Columns[j].Header).Length)
                                        dg.Columns[j].Width = (list[i][j].Length * 8) + 3;
                                Console.WriteLine(list[i]);
                                dg.Items.Add(list[i]);
                            }
                        }
                        else
                        {
                            int count = Data.conncetMS.IDUquery(query.Text);
                            MessageBox.Show("Количество затронутых строк = " + count.ToString());
                        }
                    }
                    else
                    {
                        if (query.Text.ToLower().Contains("select"))
                        {
                            string[] nameColumns = Data.connectMySQL.GetName(query.Text);
                            for (int i = 0; i < nameColumns.Length; i++)
                                dg.Columns.Add(new DataGridTextColumn { Header = nameColumns[i], CanUserResize = false, Binding = new  Binding(string.Format("[{0}]", i)) });
                            table.Children.Add(dg);
                            List<string[]> list = Data.connectMySQL.Select(query.Text);
                            //
                            // i - строка
                            // j - столбец
                            // 3 - Погрешность
                            //
                            for (int i = 0; i < list.Count; i++)
                            {
                                for (int j = 0; j < list[i].Length; j++)
                                    if (list[i][j].Length > ((string)dg.Columns[j].Header).Length)
                                        dg.Columns[j].Width = (list[i][j].Length * 8) + 3;
                                Console.WriteLine(list[i]);
                                dg.Items.Add(list[i]); 
                            }
                        }
                        else
                        {
                            int count = Data.connectMySQL.IDUquery(query.Text);
                            MessageBox.Show("Количество затронутых строк = " + count.ToString());
                        }
                    }
                }
                catch (Exception er) { new Logger().WriteInLog(LogType.Error, er.Message); }
            }    
        }

        private void ContentTextKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                query.Text += "\n";
                query.CaretIndex = query.Text.Length;
            }
        }

        private void ControlUnloaded(object sender, RoutedEventArgs e)
        {
            Data.conncetMS = null;
            Data.connectMySQL = null;
        }
    }
}
