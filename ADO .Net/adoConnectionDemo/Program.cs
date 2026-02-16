// This code demonstrates how to connect to a MySQL database using ADO.NET, execute a query, and read the results using a MySqlDataReader.
/*
using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connStr = "server=localhost;database=students;uid=root;pwd=Shreyas@123;";

        MySqlConnection con = new MySqlConnection(connStr);

        try
        {
            con.Open();
            Console.WriteLine("Connected Successfully!");

            string query = "SELECT * FROM students";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["first_name"].ToString());
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
*/


// This code demonstrates how to connect to a SQL Server database using ADO.NET, execute a query, and read the results using a SqlDataReader.
using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Application Name=SQL Server Management Studio;Command Timeout=0";

        using (SqlConnection con = new SqlConnection(connStr))
        {
            try
            {
                con.Open();
                Console.WriteLine("Connected Successfully!");

                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    /*Note: This code uses column names to access the data, which is more readable but can be less efficient.
                    int id = Convert.ToInt32(reader["Id"]);
                    string email = reader["Email"].ToString();
                    string name = reader["Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    */

                    // Using column indices is more efficient but less readable. Make sure to match the order of columns in your SELECT statement.
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string email = reader.GetString(2);
                    int age = reader.GetInt32(3);

                    // Console.WriteLine($"{id}\t{name}\t{email}\t{age}");
                    Console.WriteLine($"{id,-5}{name,-15}{email,-25}{age,-5}");// This line formats the output in a tabular form with fixed-width columns.

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
