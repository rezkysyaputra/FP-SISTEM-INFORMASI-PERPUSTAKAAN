using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Perpustakaan.Model.Context
{
    public class MyDatabaseContext : IDisposable
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "perpustakaan";
        private string uid = "root";
        private string password = "";

        public MyDatabaseContext()
        {
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            string connectionString = $"Server={server};Database={database};User ID={uid};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void Dispose()
        {
            if (connection != null)
            {
                try
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
                finally
                {
                    connection.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
