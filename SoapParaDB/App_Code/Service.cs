using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }


    public SqlConnection GetConnection()
    {
        return new SqlConnection("Server=MSI\\SQLEXPRESS;Database=VendingMachineDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }


    public bool testconnection()
    {
        SqlConnection conn = GetConnection();
        try
        {
            conn.Open();
            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public user[] GetUsers()
    {
        SqlConnection conn = GetConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM users", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        List<user> users = new List<user>();
        while (reader.Read())
        {
            user u = new user();
            u.id = reader.GetInt32(0);
            u.username = reader.GetString(1);
            u.password = reader.GetString(2);
            users.Add(u);
        }
        conn.Close();
        return users.ToArray();
    }

    public user[] Addusers(user user)
    {
        SqlConnection conn = GetConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", conn);
        cmd.Parameters.AddWithValue("@username", user.username);
        cmd.Parameters.AddWithValue("@password", user.password);
        cmd.ExecuteNonQuery();
        conn.Close();
        return GetUsers();
    }
}
