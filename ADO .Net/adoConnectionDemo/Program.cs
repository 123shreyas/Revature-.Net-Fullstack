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
using Microsoft.Data.SqlClient;//

class Program
{
    static void Main()
    {
        // Connection string to connect to the SQL Server database. It specifies the data source, initial catalog, integrated security, and other parameters.
        string connStr =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDB;Integrated Security=True;TrustServerCertificate=True;";
        // sqlconnection is used to establish a connection to the database. It takes the connection string as a parameter. The connection string contains information about the database server, database name, authentication method, and other settings required to connect to the database.
        using (SqlConnection con = new SqlConnection(connStr))// The using statement ensures that the SqlConnection is properly disposed of, even if an exception occurs. It automatically calls con.Dispose() at the end of the block, which closes the connection if it's still open.
        {
            try
            {
                con.Open();// Opens the connection to the database. If the connection is successful, it will print "Connected Successfully!" to the console.
                Console.WriteLine("Connected Successfully!\n");

                // ExecuteNonQuery(con);
                ExecuteScalar(con);
                ExecuteReader(con);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();// Closes the connection to the database if it is still open. This is important to free up resources and avoid potential connection leaks.
                    Console.WriteLine("\nConnection Closed.");
                }
            }
        }
    }

    // This method demonstrates how to use ExecuteNonQuery to execute an INSERT statement that adds a new user to the Users table. It then prints the number of rows affected by the query.
    // static void ExecuteNonQuery(SqlConnection con)
    // {
    //     string query = "INSERT INTO Users (Name, Email, Age) VALUES ('TestUser', 'test@gmail.com', 28)";
    //     SqlCommand cmd = new SqlCommand(query, con);

    //     int rows = cmd.ExecuteNonQuery();
    //     Console.WriteLine("Inserted Rows: " + rows);
    // }

    // This method demonstrates how to use ExecuteScalar to retrieve a single value from the database, in this case, the count of users in the Users table.
    static void ExecuteScalar(SqlConnection con)
    {
        string query = "SELECT COUNT(*) FROM Users";
        // SQLCommand is used to execute a query against the database. It takes the query string and the SqlConnection object as parameters. The ExecuteScalar method executes the query and returns the first column of the first row in the result set, which is expected to be the count of users in this case.
        SqlCommand cmd = new SqlCommand(query, con);

        int count = Convert.ToInt32(cmd.ExecuteScalar());
        Console.WriteLine(count);
    }

    // This method demonstrates how to use ExecuteReader to execute a SELECT statement that retrieves all users from the Users table. It then reads the results using a SqlDataReader and prints the user details in a formatted table.
    static void ExecuteReader(SqlConnection con)
    {
        string query = "SELECT Id, Name, Email, Age FROM Users";
        SqlCommand cmd = new SqlCommand(query, con);
        // SqlDataReader is used to read a forward-only stream of rows from a SQL Server database. The ExecuteReader method executes the command and returns a SqlDataReader object that can be used to read the results of the query.
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nUsers List:");
        Console.WriteLine($"{"Id",-5}{"Name",-15}{"Email",-25}{"Age",-5}");
        Console.WriteLine(new string('-', 50));

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
}

