using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.Db
{
	class Database : IDatabase
	{

		private String connString = "Server=localhost;Database=desafio7;Uid=root;Pwd=11235813";

		private static Database instance = null;

		private Database() { }

		public static Database GetInstance()
		{
			if (instance == null)
			{
				instance = new Database();
			}

			return instance;
		}

		public MySqlConnection Conexao()
		{
			return new MySqlConnection(connString);
		}

		public void ExecutaCommando(string comando)
		{
			var connection = new MySqlConnection(connString);
			var command = connection.CreateCommand();

			try
			{
				connection.Open();
				command.CommandText = comando;
				command.ExecuteNonQuery();
			}
			catch (Exception e)
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