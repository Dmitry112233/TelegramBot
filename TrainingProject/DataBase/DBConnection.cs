using System;
using MySql.Data.MySqlClient;

namespace TrainingProject.DataBase
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = "BmaDataShow";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            return new DBConnection();
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=18.209.67.91; database={0}; UID=root; password=Dimka-Admin93", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }        
    }
}