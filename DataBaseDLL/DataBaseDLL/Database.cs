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

        string[] GetName(string command);
        
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
            try
            {
                conn.Open();
                int count = new SqlCommand(command, conn).ExecuteNonQuery();
                conn.Close();
                return count;
            }
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
        }

        /// <summary>
        /// Выборка данных
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns> Список со вложенным массивом строк </returns>
        public List<string[]> Select(string command)
        {
            try
            {
                List<string[]> rows = new List<string[]>();
                conn.Open();
                SqlDataReader dr = new SqlCommand(command, conn).ExecuteReader();
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
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
        }

        public string[] GetName(string command)
        {
            try
            {
                conn.Open();
                SqlDataReader dr = new SqlCommand(command, conn).ExecuteReader();
                string[] array = new string[dr.FieldCount];
                for (int i = 0; i < dr.FieldCount; i++)
                    array[i] = dr.GetName(i);
                dr.Close();
                conn.Close();
                return array;
            }
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
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
            try
            {
                conn.Open();
                int count = new MySqlCommand(command, conn).ExecuteNonQuery();
                conn.Close();
                return count;
            }
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
        }

        /// <summary>
        /// Выборка данных
        /// </summary>
        /// <param name="command"> Команда для выполнения </param>
        /// <returns> Список со вложенным массивом строк </returns>
        public List<string[]> Select(string command)
        {
            try 
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
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
        }

        public string[] GetName(string command)
        {
            try
            {
                string[] array = { };
                conn.Open();
                MySqlDataReader dr = new MySqlCommand(command, conn).ExecuteReader();
                if (dr.HasRows)
                {
                    array = new string[dr.FieldCount];
                    for (int i = 0; i < dr.FieldCount; i++)
                        array[i] = dr.GetName(i);
                }
                dr.Close();
                conn.Close();
                return array;
            }
            finally { if ( conn.State == System.Data.ConnectionState.Open ) conn.Close(); }
        }
    }
}
