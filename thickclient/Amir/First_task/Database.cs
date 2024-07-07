using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace First_task
{
    internal class Database
    {
        private string connectionString;
        private MySqlConnection connection;

        public Database()
        {
            string server = "localhost";
            string database = "login_.net";
            string username = "root";
            string password = "";

            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool Insert(string username, string password)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();

                    Console.WriteLine("Data inserted successfully.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting data: " + ex.Message);
                return false;
            }
        }
        public DataTable Login(string username, string password)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable userData = new DataTable();
                        adapter.Fill(userData);
                        return userData;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing login query: " + ex.Message);
                return null;
            }
        }
    }
}