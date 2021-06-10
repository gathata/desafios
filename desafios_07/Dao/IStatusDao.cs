using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.DAO
{
	public class DaoBaseImpl : IDaoBase
	{
		IAlunosDao alunosDao;
		ICursoDao cursosDao;
		IStatusDao statusDao;

		public DaoBaseImpl()
		{
			alunosDao = new AlunosDaoImpl();
			cursosDao = new CursoDaoImpl();
			statusDao = new StatusDaoImpl();
		}

		public IAlunosDao Alunos()
		{
			return alunosDao;
		}

		public ICursoDao Cursos()
		{
			return cursosDao;
		}

		public IStatusDao Status()
		{
			return statusDao;
		}
	}
}