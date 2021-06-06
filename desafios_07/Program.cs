using System;
using System.Collections.Generic;

namespace desafios_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio 07 da Thai!\n");

            Console.WriteLine("Digite o nome do aluno e aperte enter,");
            Console.WriteLine("Em seguida, digite a nota de cada aluno pelo nome \n");

            List<Aluno> alunos = new();

            while (true)
			{
                string nome = Console.ReadLine();

                if (nome.Length < 1)
                    break;

                Aluno aluno = new();
                aluno.Nome = nome;
                alunos.Add(aluno);
			}

            if (alunos.Count > 1)
			{
                for (int i = 0; i < alunos.Count; i++)
				{
                    Console.WriteLine("Digite a nota do aluno {0}:", alunos[i].Nome);
                    var str_nota = Console.ReadLine();

                    _ = double.TryParse(str_nota, out double nota);
                    alunos[i].UltimaNota = nota;
				}
			}

            IDaoBase daoBase = new DaoBaseImpl();

            daoBase.Alunos().SalvarLista(alunos);
        }
    }
}
