using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using LoggerDLL;

namespace DataBaseDLL
{
    public interface DatabaseDL
    {

        List<string[]> Select(string command);

        int IDUquery(string command);
        
    }

    public class MSServer : DatabaseDL
    {
        private SqlConnection conn;

        /// <summary>
        /// Иниацилизация класса работы с базой данных
        /// </summary>
        /// <param name="conncetionString"> Полная строка подключения </param>
        public MSServer(string conncetionString)
        {
            Initialization(conncetionString);

            new Logger().WriteInLog(LogType.Info, "Инициализация модуля DataBase -> MSServer");
        }

        private void Initialization(string conncetionString) => conn = new SqlConnection(conncetionString); 

        /// <summary>
        /// IDU - InsertDeleteUpdate
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns></returns>
        public int IDUquery(string command)
        {
            conn.Open();
            int count = new SqlCommand(command, conn).ExecuteNonQuery();
            conn.Close();
            return count;
        }

        /// <summary>
        /// Выборка данных
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns> Список со вложенным массивом строк </returns>
        public List<string[]> Select(string command)
        {
            List<string[]> rows = new List<string[]>();
            conn.Open();
            SqlDataReader dr = new SqlCommand(command, conn).ExecuteReader();
            if (dr.HasRows)
                while(dr.Read())
                {
                    string[] columns = new string[dr.FieldCount];
                    for (int i = 0; i < dr.FieldCount; i++)
                        columns[i] = dr[i].ToString();
                    rows.Add(columns);
                }
            dr.Close();
            conn.Close();
            return rows;
        }

    }

    public class MySQL : DatabaseDL
    {
        private MySqlConnection conn;

        /// <summary>
        /// Иниацилизация класса работы с базой данных
        /// </summary>
        /// <param name="conncetionString"> Полная строка подключения </param>
        public MySQL(string conncetionString)
        {
            Initialization(conncetionString);

            new Logger().WriteInLog(LogType.Info, "Инициализация модуля DataBase -> MySql");
        }

        private void Initialization(string conncetionString) => conn = new MySqlConnection(conncetionString);

        /// <summary>
        /// IDU - InsertDeleteUpdate
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns></returns>
        public int IDUquery(string command)
        {
            conn.Open();
            int count = new MySqlCommand(command, conn).ExecuteNonQuery();
            conn.Close();
            return count;
        }

        /// <summary>
        /// Выборка данных
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns> Список со вложенным массивом строк </returns>
        public List<string[]> Select(string command)
        {
            List<string[]> rows = new List<string[]>();
            conn.Open();
            MySqlDataReader dr = new MySqlCommand(command, conn).ExecuteReader();
            if (dr.HasRows)
                while (dr.Read())
                {
                    string[] columns = new string[dr.FieldCount];
                    for (int i = 0; i < dr.FieldCount; i++)
                        columns[i] = dr[i].ToString();
                    rows.Add(columns);
                }
            dr.Close();
            conn.Close();
            return rows;
        }
    }
}
