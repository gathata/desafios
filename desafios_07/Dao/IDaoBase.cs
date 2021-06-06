using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.DAO
{
	public interface IDaoBase
	{
		IStatusDao Status();
		ICursoDao Cursos();
		IAlunosDao Alunos();
	}
}
