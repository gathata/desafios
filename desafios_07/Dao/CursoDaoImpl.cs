using desafio_007.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.DAO
{
	class CursoDaoImpl : ICursoDao
	{
		public bool AlteraCurso(Curso curso)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("update cursos set nome='{0}' where id={1};", curso.Nome, curso.Id));
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public Curso CarregaCurso(int id)
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			Curso curso = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select nome from cursos where id={0};", id);
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					if (dataReader.Read())
					{
						curso.Id = id;
						curso.Nome = dataReader.GetString(0);
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

			return curso;
		}

		public List<Curso> CarregaCursos()
		{
			var connection = Database.GetInstance().Conexao();
			var command = connection.CreateCommand();

			List<Curso> cursos = new();

			try
			{
				connection.Open();
				command.CommandText = String.Format("select id, nome from cursos;");
				var dataReader = command.ExecuteReader();

				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						Curso curso = new();
						curso.Id = dataReader.GetInt32(0);
						curso.Nome = dataReader.GetString(1);
						cursos.Add(curso);
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

			return cursos;
		}

		public bool DeletaCurso(Curso curso)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("delete from cursos where id={0};", curso.Id));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}

		public bool NovoCurso(Curso curso)
		{
			try
			{
				Database.GetInstance().ExecutaCommando(String.Format("insert into cursos(id, nome) values({0}, '{1}');", curso.Id, curso.Nome));
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