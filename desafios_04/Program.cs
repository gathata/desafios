using System;

namespace desafios_04
{
    class Aluno
    {
        public string Nome;
        public Int32 Idade;
        public double Nota;
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int ALUNOS_QTD = 3;

            Console.WriteLine("Soma Notas\n==========\n\n");
            Aluno[] alunos = new Aluno[ALUNOS_QTD];

            for (int i = 0; i < ALUNOS_QTD; i++)
            {
                Console.WriteLine ("Qual o nome do aluno {0}:", i+1);
                string nome = Console.ReadLine ();
                Console.WriteLine ("Qual a idade do aluno {0}:", i+1);
                string idade = Console.ReadLine ();
                Console.WriteLine ("Qual a nota do aluno número {0}:", i+1);
                string nota = Console.ReadLine();

                alunos[i] = new Aluno();
                alunos[i].Nome = nome;
                alunos[i].Idade = int.Parse(idade);
                alunos[i].Nota = double.Parse(nota);  
            }

            double soma = 0;

            foreach (var aluno in alunos)
			{
                soma += aluno.Nota;
			}

            Console.WriteLine("Soma das notas: {0}\n", soma);
        }
    }
}
