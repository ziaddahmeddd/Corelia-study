using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

public class DatabaseHelper
{
    private string connectionString;
    private MySqlConnection conn;
    public DatabaseHelper()
    {
        this.connectionString = "server=localhost;database=userdatabase;user=root;password=;";
        conn = new MySqlConnection(connectionString);
        OpenConnection();

    }

    public void OpenConnection()
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                MessageBox.Show("Connection successful!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void CloseConnection()
    {
        try
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                //MessageBox.Show("Connection closed!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    public bool RegisterUser(string username, string password, string email)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO users (username, password, email) VALUES (@username, @password, @.email)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@.email", email);
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public DataTable ValidateUser(string username, string password)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM users WHERE username=@username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable userTable = new DataTable();
            adapter.Fill(userTable);

            return userTable;
        }
    }
}
