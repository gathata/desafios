using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafios_07
{
	public class Aluno
	{
		public int Id { get; set; }
		public String Nome { get; set; }
		public Curso Curso { get; set; }
		public Status Status { get; set; }
		public double UltimaNota { get; set; }
	}
}