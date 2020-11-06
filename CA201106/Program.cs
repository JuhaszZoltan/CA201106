using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201106
{
    class Program
    {
        static string connectionString;
        static SqlConnection connection;
        static void Main()
        {
            connectionString =
                @"Server = (localdb)\MSSQLLocalDB;" +
                "Database = elso;";
            connection = new SqlConnection(connectionString);

            Select();
            Insert();
            Select();

            Console.ReadKey();
        }

        static void Select()
        {
            connection.Open();
            var sqlQueryString = "SELECT nev FROM proba WHERE kor >= 18;";
            var sqlCommand = new SqlCommand(sqlQueryString, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            connection.Close();
        }
        static void Insert()
        {
            Console.Write("neved: ");
            var nevem = Console.ReadLine();
            Console.Write("korod: ");
            var korom = Console.ReadLine();
            connection.Open();
            var sqlCmd = new SqlCommand(
                $"INSERT INTO proba VALUES ('{nevem}', {korom});",
                connection);
            var adapter = new SqlDataAdapter();
            adapter.InsertCommand = sqlCmd;
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();
            connection.Close();

            Console.WriteLine("siker!");
        }
    }
}
