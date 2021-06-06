using Data.MySqlClient;
using System;

namespace desafio_007.Db
{
	public interface IDatabase
	{
		void ExecutaCommando(String command);
		MySqlConnection Conexao();
	}
}
