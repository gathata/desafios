using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_007.DAO
{
	public interface ICursoDao
	{
		bool NovoCurso(Curso curso);
		Curso CarregaCurso(int id);
		bool AlteraCurso(Curso curso);
		bool DeletaCurso(Curso curso);
		List<Curso> CarregaCursos();

	}
}
