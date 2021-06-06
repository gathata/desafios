using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafios_07
{
    class AlunosDaoImpl : IAlunosDao
    {
        public bool AlteraAluno (Aluno aluno)    
        {
            try
            {
                Database.GetInstance().ExecutaComando(String.Format("update alunos set nome= '{0}', nota={1} where id {2};", aluno.UltimoNota , aluno.Id));
                 
            }
            catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public Aluno CarregaAluno(int id)
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			Aluno aluno = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select nome, nota from aluno where id={0};", id);
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					if (dataReader.Read())
					{
						aluno.Id = id;
						aluno.Nome = dataReader.GetString(0);
						aluno.UltimaNota = dataReader.GetDouble(1);
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

			return aluno;
		}

		public List<Aluno> CarregaAlunos()
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			List<Aluno> alunos = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select id, nome, nota from status;");
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						Aluno aluno = new();
						aluno.Id = dataReader.GetInt32(0);
						aluno.Nome = dataReader.GetString(1);
						aluno.UltimaNota = dataReader.GetDouble(2);
						alunos.Add(aluno);
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

			return alunos;
		}

		public bool DeletaAluno(Aluno aluno)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("delete from alunos where id={0};", aluno.Id));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public bool NovoAluno(Aluno aluno)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("insert into alunos(id, nome, nota) values({0}, '{1}', {2});", aluno.Id, aluno.Nome, aluno.UltimaNota));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public bool SalvarLista(List<Aluno> alunos)
		{
			foreach (var aluno in alunos)
			{
				if (!NovoAluno(aluno))
					return false;
			}

			return true;
        }
    }
}