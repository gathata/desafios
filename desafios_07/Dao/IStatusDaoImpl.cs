using desafio_007.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.DAO
{
	class StatusDaoImpl : IStatusDao
	{
		public bool AtualizaStatus(Status status)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("update status set nome='{0}' where id={1};", status.Nome, status.Id));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public Status CarregaStatus(int id)
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			Status status = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select nome from status where id={0};", id);
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					if (dataReader.Read())
					{
						status.Id = id;
						status.Nome = dataReader.GetString(0);
					}
				}

				dataReader.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return status;
		}

		public List<Status> CarregaStatus()
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			List<Status> statuses = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select id, nome from status;");
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						Status status = new();
						status.Id = dataReader.GetInt32(0);
						status.Nome = dataReader.GetString(1);
						statuses.Add(status);
					}
				}

				dataReader.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return statuses;
		}

		public bool DeletaStatus(Status status)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("delete from status where id={0};", status.Id));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public bool NovoStatus(Status status)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("insert into status(id, nome) values({0}, '{1}');", status.Id, status.Nome));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}
	}
}