using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perpustakaan.Model.Repository
{
    using MySql.Data.MySqlClient;
    using Perpustakaan.Model.Context;

    public class UserRepository
    {
        private MySqlConnection _conn;

        public UserRepository(MyDatabaseContext context)
        {
            _conn = context.GetConnection();
        }

        public bool IsValidUser(string userName, string password)
        {
            bool result = false;

            string sql = @"SELECT COUNT(*) AS row_count
                       FROM user
                       WHERE username = @userName AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["row_count"]) > 0;
                    }
                }
            }

            return result;
        }
    }

}
