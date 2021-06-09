using System;
using System.Collections.Generic;
namespace exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a quantidade de alunos: ");
            string quantidade = Console.ReadLine ();
            int a = Int32.Parse (quantidade);
            
            List<string> listaNomes = new List<string>();

            List<int> listadeNotas = new List<int> ();

            
            for (int i = 1; i <= a; i++)
            
            {
                Console.WriteLine ("Digite o nome do aluno {0}:", i);
                string nome = Console.ReadLine ();
                Console.WriteLine ("Qual a nota do aluno?");
                string nota = Console.ReadLine ();
                int inota = Int32.Parse (nota);

                listaNomes.Add(nome);
                listadeNotas.Add(inota);
            }

            int maiorNota = 0;
            for (int i = 1; i < a; i++)
            {
                if (listadeNotas[i] > listadeNotas[maiorNota])
                {
                    if (listaNomes[i].StartsWith ("th"))
                    {
                        if (listadeNotas[i] %2==0)
                        {       
                        
                            maiorNota = i;

                        }    

                    }

                    
                }
            }

         Console.WriteLine("A maior nota é do aluno {0}, com a nota {1}", listaNomes [maiorNota], listadeNotas [maiorNota]);

        }
    }
}
