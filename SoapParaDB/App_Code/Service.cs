using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using Npgsql;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public bool testconnection()
    {
        string connectionString = DatabaseConfig.ConnectionString;
        try
        {
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<user> getUsers()
    {
        string connectionString = DatabaseConfig.ConnectionString;

        try
        {
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM users", conn);
            var reader = cmd.ExecuteReader();
            var users = new List<user>();
            while (reader.Read())
            {
                var usr = new user
                {
                    id = reader.GetInt64(0),
                    username = reader.GetString(1),
                    password = reader.GetString(2),
                    role = (Role)Enum.Parse(typeof(Role), char.ToUpper(reader.GetString(3)[0]) + reader.GetString(3).Substring(1).ToLower())
                };
                users.Add(usr);
            }
            conn.Close();
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public bool InsertUser(user newUser)
    {
        string connectionString = DatabaseConfig.ConnectionString;
        try
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO users (username, password, role) VALUES (@username, @password, @role)", conn);
                cmd.Parameters.AddWithValue("username", newUser.username);
                cmd.Parameters.AddWithValue("password", newUser.password);
                cmd.Parameters.AddWithValue("role", newUser.role.ToString().ToLower());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool UpdateUser(user newUser)
    {
        string connectionString = DatabaseConfig.ConnectionString;
        try
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("UPDATE users SET username = @username, password = @password, role = @role WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", newUser.id);
                cmd.Parameters.AddWithValue("username", newUser.username);
                cmd.Parameters.AddWithValue("password", newUser.password);
                cmd.Parameters.AddWithValue("role", newUser.role.ToString().ToLower());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool DeleteUser(Int64 id)
    {
        string connectionString = DatabaseConfig.ConnectionString;
        try
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM users WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}


public static class DatabaseConfig
{
    public static string ConnectionString
    {
        get
        {
            var connStringBuilder = new NpgsqlConnectionStringBuilder
            {
                SslMode = SslMode.Require,
                Host = "eerie-grebe-3686.jxf.gcp-europe-west1.cockroachlabs.cloud",
                Port = 26257,
                Username = "joao",
                Password = "0PBz1qwWNnfda3XWIkpJoQ",
                Database = "ISI"
            };
            return connStringBuilder.ConnectionString;
        }
    }
}

