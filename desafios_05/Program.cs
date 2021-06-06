using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace desafios_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio 005 - Conectar a um banco de dados MySQL\n");

            var connString = "Server=localhost;Database=desafio5;Uid=root;Pwd=123456";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = String.Format("insert into teste (message) values ('connection at {0}');", DateTime.Now.ToString());
                command.ExecuteNonQuery();
            }
            catch(Exception e)
			{
                Console.WriteLine(e.Message);
			}
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
